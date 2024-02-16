using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class topDownMove : MonoBehaviour
{
    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;
    public Sprite topDownPlayer;
    public Sprite normalPlayer;
    Vector2 direction;
    public float speed;
    public Animator ani;
	public Player Player;
	public Transform startTransform;
    public GameObject hatMenu;
    public Hat _hat;
    private bool hatMenuIsOpen = false;
    public Enters ent;
    public Enters _ent2;
    public Enters _ent3;
    float nrLevel;
    public RuntimeAnimatorController topDownController;
    public ShopController shop;

    void Start()
    {
        hatMenuIsOpen = false;
		Player = new Player();

    }
	public void combatLose()
	{
		Debug.Log("dead");
		Player = new Player();
		combatEnd();
		transform.position = startTransform.position;
	}
    public void combatEnd()
    {
        if(nrLevel == 1)
        {
            ent.exitCombat();
        }
        if(nrLevel == 2)
        {
            _ent2.exitCombat();
        }
        if(nrLevel == 3)
        {
            _ent3.exitCombat();
            ani.runtimeAnimatorController = topDownController;
        }
        print("0");
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Entrance")
        {
            Enters e = other.GetComponent<Enters>();
            if(e.lvName == "cave1")
            {
                e.lv1Start();
                print("fuck yea");
                nrLevel = 1;
            }
            if(e.lvName == "cave2")
            {
                print("droped");
                e.lv1Start();
                nrLevel = 2;
            }
            if(e.lvName == "cave3")
            {
                e.lv1Start();
                nrLevel = 3;
                ani.SetBool("topDown", true);
            }
        }
        if(other.tag == "shot")
        {
            shop.OpenShop(Player);
        }
    }
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.F))
        {
            if(nrLevel == 2)
            {
                _ent2.exitCombat();
                nrLevel = 3;
            }
            else if(nrLevel == 3)
            {
                _ent3.exitCombat();
            }
            else
            {
                ent.exitCombat();
                nrLevel = 2;
            }
        }*/
        direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        rb.velocity = direction * speed;
        if(direction.x < 0)
        {
            ani.SetBool("right", true);
        }
        else
        {
            ani.SetBool("right", false);

        }
        if (direction.x > 0)
        {
            ani.SetBool("left", true);
        }
        else
        {
            ani.SetBool("left", false);
        }
        if(direction.y < 0)
        {
            ani.SetBool("toward", true);
        }
        else
        {
            ani.SetBool("toward", false);
        }
        if (direction.y > 0)
        {
            ani.SetBool("away", true);
        }
        else
        {
            ani.SetBool("away", false);
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            if(hatMenuIsOpen == false)
            {
                hatMenu.SetActive(true);
                hatMenuIsOpen = true;
                print("open");
            }
            else if (hatMenuIsOpen == true)
            {
                hatMenu.SetActive(false);
                hatMenuIsOpen = false;
                print("close");
            }
        }
    }
}
