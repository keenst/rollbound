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

    void Start()
    {
        OpenShop();
    }


    // Generate abilities
    public void OpenShop()
    {
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
        // Player.dieFragments -= totalCost;
        foreach (var ability in abilitiesMarked)
        {
            // CustomiseDie(ability);
        }
    }
}
