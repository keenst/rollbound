using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    public DiceCustomization diceCustom;
    public List<GameObject> domedagen;
    public Text quote;
    public Text abName;
    public Text description;
    public Text cost;
    public Text playerMoney;

    void Start()
    {

        //OpenShop(new Player());
    }

    private void Update()
    {
        float step = 800 * Time.deltaTime;
        hand.transform.position = Vector3.MoveTowards(hand.transform.position, goalPosition, step);
    }

    // Generate abilities
    public void OpenShop(Player player)
    {
        this.gameObject.SetActive(true);
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
        _player.DieFragments = 1000;

        Dialogue();


    }


    public void CloseShop()
    {
        foreach (var victim in domedagen)
        {
            victim.SetActive(false);
        }
        diceCustom.Open(abilitiesBought, _player.Dice);
        this.gameObject.SetActive(false);
    }

    public void BuyAbility()
    {
        if (_player.DieFragments >= selectedAbility.Cost)
        {
            _player.DieFragments -= selectedAbility.Cost;
            glow.gameObject.SetActive(true);
            abilitiesBought.Add(selectedAbility);
            RemoveBoughtAbility();
            glow.SetActive(false);
        }
        else
        {
            Debug.Log("Cannot afford.");
        }
    }

    public void Dialogue()
    {
        abName.text = "Greetings.";
        quote.text = "";
        description.text = "Time is money.";
        cost.text = "";
        playerMoney.text = _player.DieFragments.ToString();
    }

    public void UpdateDialogue(Ability ability)
    {
        if (ability == null)
        {
            Dialogue();
            return;
        }
        abName.text = ability.Name;
        quote.text = ability.Quote;
        print(ability.Quote);
        description.text = ability.Description;
        cost.text = ability.Cost.ToString();
        playerMoney.text = _player.DieFragments.ToString();
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
