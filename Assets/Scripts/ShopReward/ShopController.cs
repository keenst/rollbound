using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class ShopController : MonoBehaviour
{
    public Button[] commonButtons;
    public Button[] rareButtons;
    public Button[] epicButtons;
    public List<Ability> abilitiesMarked = new();
    public GameObject hand;

    public Vector3 goalPosition;

    void Start()
    {
        OpenShop(new Player());
    }

    private void Update()
    {
        float step = 100 * Time.deltaTime;
        hand.transform.position = Vector3.MoveTowards(hand.transform.position, goalPosition, step);
    }

    // Generate abilities
    public void OpenShop(Player player)
    {
        hand.SetActive(true);
        goalPosition = new Vector3(230, 750, 0);
        hand.transform.position = goalPosition;
        abilitiesMarked.Clear();
        double fallOff = 0.4;
        Random rng = new();
        foreach (var x in commonButtons)
        {
            if (rng.NextDouble() <= 0.6 + fallOff)
            {

                x.gameObject.SetActive(true);
                fallOff -= 0.2;
            }
            else
            {
                x.gameObject.SetActive(false);
            }
        }

        fallOff = 0;

        foreach (var x in rareButtons)
        {
            if (rng.NextDouble() <= 0.45 + fallOff)
            {
                x.gameObject.SetActive(true);
                fallOff -= 0.15;
            }
            else
            {
                x.gameObject.SetActive(false);
            }
        }

        fallOff = 0;

        foreach (var x in epicButtons)
        {
            if (rng.NextDouble() <= 0.17 + fallOff)
            {
                x.gameObject.SetActive(true);
                fallOff -= 0.13;
            }
            else
            {
                x.gameObject.SetActive(false);
            }
        }
    }

    public void CloseShop()
    {
        //Player.dieFragments -= totalCost;
        foreach (var ability in abilitiesMarked)
        {
            // CustomiseDie(ability);
        }
        hand.SetActive(false);
    }


    public void MoveHand(Transform buttonTransform)
    {
        goalPosition = buttonTransform.position;
    }

    public void IdleHand()
    {
        goalPosition = new Vector3(230, 570, 0);
    }
}
