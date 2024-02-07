using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ckickPlayer : MonoBehaviour
{
    private Vector2 targetPos;
    public float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
