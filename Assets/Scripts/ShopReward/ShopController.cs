using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.U2D.Path.GUIFramework;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class ShopController : MonoBehaviour
{
    public ShopButton[] allButtons;
    public List<Ability> abilitiesBought = new();
    public GameObject hand;
    public Vector3 goalPosition;
    public GameObject glow;
    private Player _player;
    public Ability selectedAbility;
    public DiceCustomization diceCustomization;

    void Start()
    {
        OpenShop(new Player());
    }

    private void Update()
    {
        float step = 800 * Time.deltaTime;
        hand.transform.position = Vector3.MoveTowards(hand.transform.position, goalPosition, step);
    }

    // Generate abilities
    public void OpenShop(Player player)
    {
        glow.SetActive(false);
        _player = player;
        hand.SetActive(true);
        hand.transform.position = new Vector3(600,750,0);
        goalPosition = new Vector3(600, 750, 0);
        print(goalPosition);
        Random rng = new();

        for (int i = 0; i < allButtons.Length; i++)
        {
            allButtons[i].gameObject.SetActive(false);
            if (i<4)
            {
                if (rng.Next(1, 3) != 1) continue;
                
                allButtons[i].gameObject.SetActive(true);
                allButtons[i].SetAbility(Abilities.GetFromRarity(CardRarity.Common));
            }
            else if (i<8)
            {
                if (rng.Next(1,4) != 1) continue;

                allButtons[i].gameObject.SetActive(true);
                allButtons[i].SetAbility(Abilities.GetFromRarity(CardRarity.Rare));
            }
            else
            {
                if (rng.Next(1,7) != 1) continue;
                allButtons[i].gameObject.SetActive(true);
                allButtons[i].SetAbility(Abilities.GetFromRarity(CardRarity.Legendary));
            }
            
        }

        

        
    }

    public void CompletePurchase()
    {
        _player.DieFragments -= 3;
    }

    public void CloseShop()
    {
        foreach (var ability in abilitiesBought)
        {
            // CustomiseDie(ability);
        }
        hand.SetActive(false);
        glow.SetActive(false);

    }


    public void MoveHand(Transform buttonTransform)
    {
        goalPosition.x = buttonTransform.position.x;
        goalPosition.y = buttonTransform.position.y + 40;
        print(goalPosition);
    }


    public void RemoveBoughtAbility()
    {
        foreach (var x in allButtons)
        {
            if (x.isSelected)
            {
                x.gameObject.SetActive(false);
            }
        }
    }

    public void IdleHand()
    {
        goalPosition = new Vector3(600, 750, 0);
    }

    public void ClearSelect()
    {
        foreach (var x in allButtons)
        {
            x.isSelected = false;
        }
    }
}
