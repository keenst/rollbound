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

    void Start()
    {
        OpenReward();
    }

    // Reward(x,y,z) or make logic inside RewardController, that is the question!
    public void OpenReward()
    {
        confirmButton.gameObject.SetActive(true);

        for (int i = 0; i<3; i++)
        {
            Ability ability = GenerateCard();
            buttons[i].gameObject.SetActive(true);
            buttons[i].GetComponentInChildren<Text>().text = ability.Name;
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
        confirmButton.gameObject.SetActive(false);
    }
}
