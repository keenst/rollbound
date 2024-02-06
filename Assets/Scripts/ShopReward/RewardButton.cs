using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class RewardButton : MonoBehaviour
{
    public Button button;
    public RewardController controller;
    public bool isSelected = false;
    private RewardController controll;

    void Start()
    {
        Button btn = button.GetComponent<Button>();
        controll = controller.GetComponent<RewardController>();
        btn.onClick.AddListener(TaskOnClick);
    }

    // Abilities depending on a list of them I suppose? Either in RewardController or another script, we shall see.
    

    void TaskOnClick()
    {
        
        if (gameObject.CompareTag("RewConf"))
        {
            // CustomiceDice(ability 1, ability 2, ability 3);
            controll.CloseReward();
        }
        else
        {
            if (!isSelected)
            {
                button.image.color = Color.red;
                isSelected = true;
                // Check whatever ability this is and use it in the confirm block of code to save yippie eine ja cola
            }
            else
            {
                button.image.color = Color.white;
                isSelected = false;
            }
        }

    }
}
