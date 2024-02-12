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
    public Player _player = new();
    public CombatSystem combSystm;

    bool outofComb = false;
    bool intoComb = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            intoComb = true;
            ani.SetBool("changeScene", true);
        }
    }
    private void active()
    {
        ani.SetBool("changeScene", false);
        player.SetActive(false);
        cam.SetActive(true);
        startBg.SetActive(false);
        lv.SetActive(true);
        combat.SetActive(true);
        combSystm.OnStart(_player, Enemies.GetFromName("Test"));
    }
    public void combatEnd()
    {
        outofComb = true;
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
        player.transform.position = new Vector2(0, 0);
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (intoComb == true)
        {
            intoComb = false;
            Invoke("active", 1);
        }
        if (outofComb == true)
        {
            outofComb = false;
            Invoke("combEndChange", 1);
            print("2");
        }
    }
}
