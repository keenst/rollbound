using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardButton : MonoBehaviour
{
    public Button button;
    public RewardController controller;
    public bool isSelected = false;

    

    void Start()
    {
        

        Button btn = button.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void Update()
    {
        
    }


    void TaskOnClick()
    {
        if (!isSelected)
        {
            button.image.color = Color.red;
            isSelected = true;
        }
        else
        {
            button.image.color = Color.white;
            isSelected = false;
        }

    }
}
