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

    bool change = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            change = true;
            ani.SetBool("changeScene", true);

        }
    }
    private void active()
    {
        player.SetActive(false);
        cam.SetActive(true);
        startBg.SetActive(false);
        lv.SetActive(true);
        combat.SetActive(true);
    }
    public void combatEnd()
    {
        player.SetActive(true);
        cam.SetActive(false);
        lv.SetActive(false);
        combat.SetActive(false);
    }

    void Start()
    {
        
    }

    void Update()
    {
        if(change == true)
        {
            change = false;
            Invoke("active", 1);
        }
    }
}
