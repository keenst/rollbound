using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Profiling;
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

    private void Update()
    {
        controll.profitsTxt.text = ("Die fragments +" + controll.profits);
    }

    void TaskOnClick()
    {
                            // Reward Confirm
        if (gameObject.CompareTag("RewConf"))
        {

            controll.CloseReward();
        }
        else
        {
            if (isSelected)
            {
                button.image.color = Color.white;
                isSelected = false;
                switch (button.name)
                {
                    case "0":
                        controller.shouldKeepAbilities[0] = false;
                        controller.profits -= controll.displayedAbilities[0].Cost/2;
                        
                        //print("Ability 1 de-selected");
                        break;

                    case "1":
                        controller.shouldKeepAbilities[1] = false;
                        controller.profits -= controll.displayedAbilities[1].Cost / 2;

                        //print("Ability 2 de-selected");
                        break;

                    case "2":
                        controller.shouldKeepAbilities[2] = false;
                        controller.profits -= controll.displayedAbilities[2].Cost / 2;

                        //print("Ability 3 de-selected");
                        break;
                }
            }
            else
            {
                button.image.color = Color.red;
                isSelected = true;
                switch (button.name)
                {
                    case "0":
                        controller.shouldKeepAbilities[0] = false;
                        controller.profits += controll.displayedAbilities[0].Cost / 2;
                        print("Ability 1 selected");
                        break;

                    case "1":
                        controller.shouldKeepAbilities[1] = false;
                        controller.profits += controll.displayedAbilities[1].Cost / 2;
                        print("Ability 2 selected");
                        break;

                    case "2":
                        controller.shouldKeepAbilities[2] = false;
                        controller.profits += controll.displayedAbilities[2].Cost / 2;
                        print("Ability 3 selected");
                        break;
                }
            }
        }

    }
}
