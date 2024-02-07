using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        Ability newAbility = Abilities.GetFromRarity(CardRarity.Common);
        CustomiseDice(newAbility, dice);
    }


    void Update()
    {
        
    }    

    public void CustomiseDice(Ability newAbility, Dice dice)
    {
        if (newAbility is PhysicalAbility)
        {
            GameObject.Find("Side 1").GetComponent<Renderer>().material.color = new Color(128, 0, 0);
            GameObject.Find("Side 2").GetComponent<Renderer>().material.color = new Color(128, 0, 0);
            GameObject.Find("Side 3").GetComponent<Renderer>().material.color = new Color(128, 0, 0);
            GameObject.Find("Side 4").GetComponent<Renderer>().material.color = new Color(128, 0, 0);
            GameObject.Find("Side 5").GetComponent<Renderer>().material.color = new Color(128, 0, 0);
            GameObject.Find("Side 6").GetComponent<Renderer>().material.color = new Color(128, 0, 0);
            GameObject.Find("New ability").GetComponent<Renderer>().material.color = new Color(128, 0, 0);
        }
        if (newAbility is MagicalAbility)
        {
            GameObject.Find("Side 1").GetComponent<Renderer>().material.color = new Color(0, 128, 0);
            GameObject.Find("Side 2").GetComponent<Renderer>().material.color = new Color(0, 128, 0);
            GameObject.Find("Side 3").GetComponent<Renderer>().material.color = new Color(0, 128, 0);
            GameObject.Find("Side 4").GetComponent<Renderer>().material.color = new Color(0, 128, 0);
            GameObject.Find("Side 5").GetComponent<Renderer>().material.color = new Color(0, 128, 0);
            GameObject.Find("Side 6").GetComponent<Renderer>().material.color = new Color(0, 128, 0);
        }
        if (newAbility is DefensiveAbility)
        {
            GameObject.Find("Side 1").GetComponent<Renderer>().material.color = new Color(0, 128, 128);
            GameObject.Find("Side 2").GetComponent<Renderer>().material.color = new Color(0, 128, 128);
            GameObject.Find("Side 3").GetComponent<Renderer>().material.color = new Color(0, 128, 128);
            GameObject.Find("Side 4").GetComponent<Renderer>().material.color = new Color(0, 128, 128);
            GameObject.Find("Side 5").GetComponent<Renderer>().material.color = new Color(0, 128, 128);
            GameObject.Find("Side 6").GetComponent<Renderer>().material.color = new Color(0, 128, 128);
        }
    }
}
