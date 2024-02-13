using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReRoll : MonoBehaviour
{
    public Button button;

    public GameObject shop;
    ShopController shopKontroll;

    void Start()
    {
        Button btn = button.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);

        shopKontroll= shop.GetComponent<ShopController>();
    }

    void TaskOnClick()
    {
        shopKontroll.OpenShop(new Player());
    }
}
