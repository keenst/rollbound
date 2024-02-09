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
        Button btn = button.GetComponent<Button>();
        controll = controller.GetComponent<ShopController>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {

    }

}
