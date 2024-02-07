using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ckickPlayer : MonoBehaviour
{
    private Vector2 targetPos;
    public float speed = 1f;

    void Start()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButton(0))
        {
            targetPos = new Vector2(mousePos.x, mousePos.y);
        }
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed);
        
    }
}
