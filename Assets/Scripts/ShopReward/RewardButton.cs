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
                switch (button.name)
                {
                    case "0":
                        controller.abilitiesToSend[0] = controller.displayedAbilities[0];
                        print("Ability 1 selected");
                        break;

                    case "1":
                        controller.abilitiesToSend[1] = controller.displayedAbilities[1];
                        print("Ability 2 selected");
                        break;

                    case "2":
                        controller.abilitiesToSend[2] = controller.displayedAbilities[2];
                        print("Ability 3 selected");
                        break;
                }
            }
            else
            {
                button.image.color = Color.white;
                isSelected = false;
                switch (button.name)
                {
                    case "0":
                        controller.abilitiesToSend[0] = null;
                        print("Ability 1 de-selected");
                        break;

                    case "1":
                        controller.abilitiesToSend[0] = null;
                        print("Ability 2 de-selected");
                        break;

                    case "2":
                        controller.abilitiesToSend[0] = null;
                        print("Ability 3 de-selected");
                        break;
                }
            }
        }

    }
}
