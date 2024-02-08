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
    public bool[] shouldKeepAbilities = {true, true, true};

    private Player player;

    void Start()
    {
        OpenReward(new Player());
    }

    public void OpenReward(Player player)
    {
        this.player = player;
        confirmButton.gameObject.SetActive(true);


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

    
    public void CloseReward()
    {
        foreach (var x in buttons)
        {
            x.gameObject.SetActive(false);
        }


        int i = 0;
        while (i < 3)
        {
            if (shouldKeepAbilities[i])
            {
                switch (displayedAbilities[i].Rarity)
                {
                    case CardRarity.Common:
                        player.DieFragments += 5;
                        break;
                    case CardRarity.Rare:
                        player.DieFragments += 10;
                        break;
                    case CardRarity.Legendary:
                        player.DieFragments += 30;
                        break;
                }
            }
            i++;
        }

        print(player.DieFragments);
        confirmButton.gameObject.SetActive(false);
    }
}
