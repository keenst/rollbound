using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class topDownMove : MonoBehaviour
{
    public Rigidbody2D rb;
    //public SpriteRenderer spriteRenderer;
    Vector2 direction;
    public float speed;
    public Animator ani;
	public Player Player;
	public Transform startTransform;
    bool hasPickedUpHat;
    public GameObject hatMenu;
    public Hat _hat;
    private bool hatMenuIsOpen = false;
    public Enters ent;
    public Enters _ent2;
    public Enters _ent3;
    float nrLevel;

    void Start()
    {
        hatMenuIsOpen = false;

    }
    void enterLevel(string lvName)
    {
        print("UwU");
        

    }
	public void combatLose()
	{
		transform.position = startTransform.position;
		Player = new Player();
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
            }
        }
    }
    private void Awake()
    {
        
    }

    void Update()
    {
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
