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
	public List<Ability> abilityQueue;
	public Player player;

	public void Open(List<Ability> newAbilities, Player player)
	{
		abilityQueue = newAbilities;
		this.dice = player.Dice;
		this.player = player;
		openMenu(abilityQueue[0], dice);
	}

    public void openMenu(Ability newAbility, Dice dice)
    {
        currentAbility = newAbility;
		NewAbility.image.sprite = abilityImages.Get(newAbility.Name);
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
		Debug.Log(ability.Name);
        DieType dieType = ability switch
        {
            PhysicalAbility => DieType.Physical,
            MagicalAbility => DieType.Magical,
            DefensiveAbility => DieType.Defensive,
            _ => DieType.Physical
        };
        Debug.Log("Side index: " + sideIndex);
		player.Dice.ChangeAbility(dieType, sideIndex - 1, ability);
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
            deactivateComponents();

            print(abilityQueue.Count);
			abilityQueue.RemoveAt(0);
			if (abilityQueue.Count != 0)
			{
				openMenu(abilityQueue[0], dice);
			}
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
