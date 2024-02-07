using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class RewardController : MonoBehaviour
{
    public Button[] buttons;
    public Button confirmButton;
    public Ability[] displayedAbilities = new Ability[3];
    public Ability[] abilitiesToSend = new Ability[3];

    void Start()
    {
        OpenReward();
    }

    public void OpenReward()
    {
        confirmButton.gameObject.SetActive(true);
        abilitiesToSend = new Ability[3];

        for (int i = 0; i<3; i++)
        {
            Ability ability = GenerateCard();
            buttons[i].gameObject.SetActive(true);
            buttons[i].name = Convert.ToString(i);
            buttons[i].GetComponentInChildren<Text>().text = ability.Name;
            displayedAbilities[i] = ability;
        }
    }
    
    public Ability GenerateCard()
    {
        Random rng = new();
        int rngRes = rng.Next(1, 11);
        if (rngRes == 10)
        {
            return Abilities.GetFromRarity(CardRarity.Legendary);

        }
        else if (rngRes >= 6)
        {
            return Abilities.GetFromRarity(CardRarity.Rare);
        }
        else
        {
            return Abilities.GetFromRarity(CardRarity.Common);
        }
    }

    // 
    public void CloseReward()
    {
        foreach (var x in buttons)
        {
            x.gameObject.SetActive(false);
        }

        for (int i = 0; i < 3; i++)
        {
            print(abilitiesToSend[i]);
        }
        confirmButton.gameObject.SetActive(false);
    }
}
