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

    void Start()
    {
        isSelected = false;

        controll = controller.GetComponent<ShopController>();

        button.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        if (isSelected)
        {
            isSelected = false;
        }
        else
        { 
            controller.MoveHand(button.transform);
            isSelected = true;
        }
    }

}
