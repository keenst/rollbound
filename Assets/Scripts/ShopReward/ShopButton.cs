using System.Collections;
using System.Collections.Generic;
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
        Button btn = button.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {

    }

}
