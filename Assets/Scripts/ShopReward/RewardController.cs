using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEditor.U2D.Path.GUIFramework;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.UI;
using Random = System.Random;

public class RewardController : MonoBehaviour
{
    public Button[] buttons;
    public Button confirmButton;
    public Ability[] displayedAbilities = new Ability[3];
    public bool[] shouldKeepAbilities = {true, true, true};
    public RewardButton[] rewardButtons = new RewardButton[3];
    public AbilityImages abilityImages;
    public DiceCustomization diceCustom;
    public Text profitsTxt;
    public int profits = 0;

    private Player player;

    public void Start()
    {
        OpenReward(new Player());
    }

    public void OpenReward(Player player)
    {
        this.gameObject.SetActive(true);
        this.player = player;
        profitsTxt.gameObject.SetActive(true);
        confirmButton.gameObject.SetActive(true);
        for (int i = 0; i < shouldKeepAbilities.Length; i++)
        {
            shouldKeepAbilities[i] = true;
        }

        for (int i = 0; i<3; i++)
        {
            Ability ability = GenerateCard();
            buttons[i].gameObject.SetActive(true);
            buttons[i].name = Convert.ToString(i);
            buttons[i].GetComponentInChildren<Text>().text = ability.Name;
            displayedAbilities[i] = ability;
            Sprite texture = abilityImages.Get(ability.Name);
            buttons[i].image.sprite = texture;
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
        for (int i = 0; i < 3; i++)
        {
            buttons[i].image.color = Color.white;
            buttons[i].gameObject.SetActive(false);
            rewardButtons[i].isSelected = false;
        }

        foreach (var x in buttons)
        {
            x.image.color = Color.white;
            x.gameObject.SetActive(false);
        }
        profitsTxt.gameObject.SetActive(false);
        this.gameObject.SetActive(false);

        int go = 0;
        List<Ability> abilitiesToKeep = new();
        while (go < 3)
        {
            if (shouldKeepAbilities[go])
            {
                abilitiesToKeep.Add(displayedAbilities[go]);
            }

                if (!shouldKeepAbilities[go])
                {
                    switch (displayedAbilities[go].Rarity)
                    {
                        case CardRarity.Common:
                            player.DieFragments += 5;
                            break;
                        case CardRarity.Rare:
                            player.DieFragments += 10;
                            break;
                        case CardRarity.Legendary:
                            player.DieFragments += 25;
                            break;
                    }
                }

                go++;
            }
            diceCustom.Open(abilitiesToKeep, player);
            print(player.DieFragments);
            confirmButton.gameObject.SetActive(false);


    }
}
