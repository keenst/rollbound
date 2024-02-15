using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceCustomization : MonoBehaviour
{
    private int selectedSideIndex;
    private Dice dice;
    public Ability currentAbility;
    public GameObject[] objectsToActivate = new GameObject[9];
    public Button[] dieSides = new Button[6];
    public Button Cancel;
    public Button Confirm;
    public Button NewAbility;
    public AbilityImages abilityImages;

    void Start()
    {
        dice = new(
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
        randomiseAbility();
        openMenu(currentAbility, dice);
    }
    public void openMenu(Ability newAbility, Dice dice)
    {
        activateComponents();
        Die die = dice.GetDie(DieType.Physical);
        switch (currentAbility)
        {
            case PhysicalAbility:
                die = dice.GetDie(DieType.Physical);
                break;

            case MagicalAbility:
                die = dice.GetDie(DieType.Magical);
                break;

            case DefensiveAbility:
                die = dice.GetDie(DieType.Defensive);
                break;
        } 
        for (int i = 0; i < dieSides.Length; i++)
        {
            Sprite texture = abilityImages.Get(die.abilities[i].Name);
            dieSides[i].image.sprite = texture;
        }
    }
    public void activateComponents()
    {
        foreach (var GameObject in objectsToActivate)
        {
            GameObject.SetActive(true);
        }
        deactivateCancelAndConfirm();
        Debug.Log("Components activated");
    }
    public void deactivateComponents()
    {
        foreach (var GameObject in objectsToActivate)
        {
            GameObject.SetActive(false);
        }
        Debug.Log("Components deactivated");
    }
    private void replaceAbility(Ability ability, int sideIndex, Dice dice)
    {
        DieType dieType = ability switch
        {
            PhysicalAbility => DieType.Physical,
            MagicalAbility => DieType.Magical,
            DefensiveAbility => DieType.Defensive,
            _ => DieType.Physical
        };
        Debug.Log("Side index: " + sideIndex);
        Die die = dice.GetDie(dieType);
        die.abilities[sideIndex - 1] = ability;
    }
    private void randomiseAbility()
    {
        currentAbility = Abilities.GetFromRarity(CardRarity.Common);
        Sprite texture = abilityImages.Get(currentAbility.Name);
        NewAbility.image.sprite = texture;
        Debug.Log(currentAbility);
    }
    public void RegisterSelectedSide(int sideIndex)
    {
        selectedSideIndex = sideIndex;
        activateCancelAndConfirm();
        Debug.Log("Selected side: " + sideIndex);
    }
    public void activateCancelAndConfirm()
    {
        Cancel.interactable = true;
        Confirm.interactable = true;
    }
    public void deactivateCancelAndConfirm()
    {
        Cancel.interactable = false;
        Confirm.interactable = false;
    }
    public void confirmation()
    {
        if (selectedSideIndex != -1)
        {
            replaceAbility(currentAbility, selectedSideIndex, dice);
            Debug.Log("Ability on side " + selectedSideIndex + " updated to " + currentAbility);
            selectedSideIndex = -1;
            randomiseAbility();
            deactivateComponents();
            openMenu(currentAbility, dice);
        }
        else
        {
            Debug.Log("No side selected to update ability.");
        }            
    }
    public void cancel()
    {
        if (selectedSideIndex >= 1)
        {
            deactivateCancelAndConfirm();
            selectedSideIndex = -1;
            Debug.Log("Deselected all sides");
        }
        else
        {
            Debug.Log("No side to deselect");
        }
    }
}
