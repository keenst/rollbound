using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardButton : MonoBehaviour
{
    public Button button;
    public RewardController controller;
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
        Debug.Log("You have clicked the button!");
    }
}
