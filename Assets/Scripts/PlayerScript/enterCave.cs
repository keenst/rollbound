using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enterCave : MonoBehaviour
{
    [SerializeField] Animator ani;
    [SerializeField] private GameObject startBg;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject cam;
    [SerializeField] private GameObject lv;
    [SerializeField] private GameObject combat;
    [SerializeField] private GameObject nextPart;
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject lvTrigger;
    public Player _player = new();
    public CombatSystem combSystm;


    void lv1()
    {
        startBg.SetActive(false);
        player.SetActive(false);
        cam.SetActive(true);
        lv.SetActive(true);
        combat.SetActive(true);
        combSystm.OnStart(_player, Enemies.GetFromName("Test"));
        ani.SetBool("changeScene", false);
        print("start combat");
    }
    public void combatEnd()
    {
        ani.SetBool("changeScene", true);
        print("1");
        Update();
    }
    private void combEndChange()
    {
        ani.SetBool("changeScene", false);
        player.SetActive(true);
        cam.SetActive(false);
        lv.SetActive(false);
        combat.SetActive(false);
        nextPart.SetActive(true);
        print("3");
        player.transform.position = new Vector2(28, -6);
    }

    void Start()
    {
        
    }

    void Update()
    {

    }
}
