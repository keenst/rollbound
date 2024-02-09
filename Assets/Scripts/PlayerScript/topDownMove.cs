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

    void Start()
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
    }
}
