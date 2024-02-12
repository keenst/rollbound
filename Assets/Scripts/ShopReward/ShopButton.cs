using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UI;

public class ShopButton : MonoBehaviour
{
    public Button button;
    public ShopController controller;
    public bool isSelected = false;
    private ShopController controll;

    void Start()
    {
        controll = controller.GetComponent<ShopController>();

        button.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        if (isSelected)
        {

        }
        else
        {
            controller.MoveHand(button.transform);
            //move hand based on location of ability
        }
    }

}
