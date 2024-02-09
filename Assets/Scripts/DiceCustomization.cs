using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceCustomization : MonoBehaviour
{
    private int selectedSideIndex = -1;
    public Ability currentAbility;

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
            ChangeColor1(Color.red);
            ChangeText1("Physical ability");
        }
        if (newAbility is MagicalAbility)
        {
            ChangeColor1(Color.blue);
            ChangeText1("Magical ability");
        }
        if (newAbility is DefensiveAbility)
        {
            ChangeColor1(Color.green);
            ChangeText1("Defensive ability");
        }
    }
    public void newAbilityCTM(Ability currentAbility)
    {
        if (currentAbility is PhysicalAbility)
        {
            ChangeColor(Color.red);
            ChangeText("Physical ability");
        }
        if (currentAbility is MagicalAbility)
        {
            ChangeColor(Color.blue);
            ChangeText("Magical ability");
        }
        if (currentAbility is DefensiveAbility)
        {
            ChangeColor(Color.green);
            ChangeText("Defensive ability");
        }
    }
    private void ChangeColor(Color color)
    {
        GameObject.Find("New ability").GetComponent<Image>().color = color;
    }
    private void ChangeText(string text)
    {
        GameObject.Find("New ability").GetComponentInChildren<Text>().text = text;
    }
    private void ChangeColor1(Color color)
    {
        GameObject.Find("Side " + selectedSideIndex).GetComponent<Image>().color = color;
    }
    private void ChangeText1(string text)
    {
        GameObject.Find("Side " + selectedSideIndex).GetComponentInChildren<Text>().text = text;
    }
    public void RandomiseAbility()
    {
        currentAbility = Abilities.GetFromRarity(CardRarity.Common);
        Debug.Log("Current ability updated to " + currentAbility);
        newAbilityCTM(currentAbility);
    }
    public void RegisterSelectedSide(int sideIndex)
    {
        selectedSideIndex = sideIndex;
        Debug.Log("Selected side: " + sideIndex);
    }
    public void confirmation()
    {            
        if (selectedSideIndex != -1)
        { 
            CustomiseDice(currentAbility);
            Debug.Log("Ability on side " + selectedSideIndex + " updated to " + currentAbility);
            selectedSideIndex = -1;            
            RandomiseAbility();            
        }
        else
        {
            Debug.Log("No side selected to update ability.");
        }            
    }

}
