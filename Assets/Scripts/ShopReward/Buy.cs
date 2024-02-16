using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buy : MonoBehaviour
{
    public Button button;
    public ShopController controller;

    private ShopController controll;
    void Start()
    {
        controll = controller.GetComponent<ShopController>();

        button.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        controll.glow.SetActive(false);
        controll.abilitiesBought.Add(controll.selectedAbility);
        controller.RemoveBoughtAbility();
        //Player.dieFragments -= 
    }
}
