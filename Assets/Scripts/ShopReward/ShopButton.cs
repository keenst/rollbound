using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UI;

public class ShopButton : MonoBehaviour
{
    public Button button;
    public ShopController controller;
    public bool isSelected;
    public AbilityImages abilityImages;
    public Ability buttonAbility;

    void Start()
    {
        isSelected = false;



        button.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        controller.IdleHand();
        controller.selectedAbility = null;
        controller.glow.SetActive(false);

        if (!isSelected)
        {
            controller.glow.SetActive(true);
            controller.glow.transform.position = button.transform.position;
            controller.MoveHand(button.transform);
            controller.ClearSelect();

            isSelected = true;
            controller.selectedAbility = buttonAbility;
        }
        else
        {
            controller.ClearSelect();
        }

    }



    public void SetAbility (Ability ability)
    {
        button.image.sprite = abilityImages.Get(ability.Name);
        buttonAbility = ability;
    }

}
