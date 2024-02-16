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
    private ShopController controll;
    public AbilityImages abilityImages;
    public Ability buttonAbility;

    void Start()
    {
        isSelected = false;


        controll = controller.GetComponent<ShopController>();

        button.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        controll.IdleHand();
        controll.selectedAbility = null;
        controll.glow.SetActive(false);

        if (!isSelected)
        {
            controll.glow.SetActive(true);
            controll.glow.transform.position = button.transform.position;
            controller.MoveHand(button.transform);
            controll.ClearSelect();

            isSelected = true;
            controll.selectedAbility = buttonAbility;
        }
        else
        {
            controll.ClearSelect();
        }

    }



    public void SetAbility (Ability ability)
    {
        button.image.sprite = abilityImages.Get(ability.Name);
        buttonAbility = ability;
    }

}
