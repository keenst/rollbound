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
        //Player.dieFragments -= totalCost;
        foreach(var x in controll.abilitiesBought)
        {
        }
    }
}
