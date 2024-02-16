using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enters : MonoBehaviour
{
    public string lvName;

    public Animator ani;
    [SerializeField] private GameObject startBg;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject cam;
    [SerializeField] private GameObject combatBg;
    [SerializeField] private GameObject nextPart;
    [SerializeField] private GameObject combat;
    [SerializeField] private GameObject lightDarkness;
    [SerializeField] private GameObject darkness;
    private AudioClip ambience;
    private AudioClip combatAmbience;
    public Player _player = new();
    public CombatSystem combSystm;
    public float x;
    public float y;

    bool outofComb = false;
    bool intoComb = false;
    
    public void lv1Start()
    {
        intoComb = true;
        ani.SetBool("changeScene", true);
    }
    void lv1()
    {
        lightDarkness.SetActive(false);
        darkness.SetActive(false);
        startBg.SetActive(false);
        player.SetActive(false);
        cam.SetActive(true);
        combatBg.SetActive(true);
        combat.SetActive(true);
        combSystm.OnStart(_player, Enemies.GetFromName("Zombie"));
        ani.SetBool("changeScene", false);
        print("start combat");
        if (lvName == "cave1")
        {
            SoundManagerScript.PlaySound("Cave Combat Ambience");
        }
    }
    public void exitCombat()
    {
        print("1");
        outofComb = true;
        ani.SetBool("changeScene", true);
        Update();
    }
    void combEndChange()
    {
        darkness.SetActive(true);
        ani.SetBool("changeScene", false);
        player.SetActive(true);
        cam.SetActive(false);
        combatBg.SetActive(false);
        combat.SetActive(false);
        nextPart.SetActive(true);
        print("3");
        player.transform.position = new Vector2(x, y);
        //lvTrigger.SetActive(false);
        if (lvName == "cave1")
        {
            SoundManagerScript.PlaySound("Cave Ambience");
        }
        else if (lvName == "cave2")
        {
            SoundManagerScript.PlaySound("DungeonDeep Ambience");
        }
        else if (lvName == "cave3")
        {
            SoundManagerScript.PlaySound("Ruined Library Ambience");

        }
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (intoComb == true)
        {
            intoComb = false;
            Invoke("lv1", 1);
        }
        if (outofComb == true)
        {
            outofComb = false;
            Invoke("combEndChange", 1);
            print("2");
        }
    }
}
