using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardController : MonoBehaviour
{
    public Button[] buttons;

    void Start()
    {
        OpenReward();
    }

    void Update()
    {
        
    }

    // Reward(x,y,z) or make logic inside RewardController, that is the question!
    public void OpenReward()
    {
        foreach (var x in buttons)
        {
            x.gameObject.SetActive(true);
        }
    }

    public void CloseReward()
    {
        foreach (var x in buttons)
        {
            x.gameObject.SetActive(false);
        }
    }
}
