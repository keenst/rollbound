using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceCustomization : MonoBehaviour
{
    void Start()
    {
        Dice dice = new(
            new Die(
                Abilities.GetFromName("Bite"),
                Abilities.GetFromName("Bite"),
                Abilities.GetFromName("Bite"),
                Abilities.GetFromName("Rock Throw"),
                Abilities.GetFromName("Rock Throw"),
                Abilities.GetFromName("Rock Throw")),
            new Die(
                Abilities.GetFromName("Ignite"),
                Abilities.GetFromName("Ignite"),
                Abilities.GetFromName("Ignite"),
                Abilities.GetFromName("Freeze"),
                Abilities.GetFromName("Freeze"),
                Abilities.GetFromName("Freeze")),
            new Die(
                Abilities.GetFromName("Heal"),
                Abilities.GetFromName("Heal"),
                Abilities.GetFromName("Heal"),
                Abilities.GetFromName("Block"),
                Abilities.GetFromName("Block"),
                Abilities.GetFromName("Block"))
            );
        
        RandomiseAbility();
    }


    void Update()
    {
    
    }

    public void CustomiseDice(Ability newAbility)
    {
        if (newAbility is PhysicalAbility)
        {
            ChangeColor(Color.red);
            ChangeText("Physical ability");
        }
        if (newAbility is MagicalAbility)
        {
            ChangeColor(Color.blue);
            ChangeText("Magical ability");
        }
        if (newAbility is DefensiveAbility)
        {
            ChangeColor(Color.green);
            ChangeText("Defensive ability");
        }
    }
    private void ChangeColor(Color color)
    {
        GameObject.Find("Side 1").GetComponent<Image>().color = color;
        GameObject.Find("Side 2").GetComponent<Image>().color = color;
        GameObject.Find("Side 3").GetComponent<Image>().color = color;
        GameObject.Find("Side 4").GetComponent<Image>().color = color;
        GameObject.Find("Side 5").GetComponent<Image>().color = color;
        GameObject.Find("Side 6").GetComponent<Image>().color = color;
        GameObject.Find("Cancel").GetComponent<Image>().color = Color.white;
        GameObject.Find("Confirm").GetComponent<Image>().color = Color.white;
    }
    private void ChangeText(string text)
    {
        GameObject.Find("Side 1").GetComponentInChildren<Text>().text = text;
        GameObject.Find("Side 2").GetComponentInChildren<Text>().text = text;
        GameObject.Find("Side 3").GetComponentInChildren<Text>().text = text;
        GameObject.Find("Side 4").GetComponentInChildren<Text>().text = text;
        GameObject.Find("Side 5").GetComponentInChildren<Text>().text = text;
        GameObject.Find("Side 6").GetComponentInChildren<Text>().text = text;
    }
    public void RandomiseAbility()
    {
        Ability newAbility = Abilities.GetFromRarity(CardRarity.Common);
        CustomiseDice(newAbility);
    }
    public void ReRollAbility()
    {
        RandomiseAbility();
        Debug.Log("Hello");
    }
}
