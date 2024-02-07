using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private PlayerInput playerInput;
    private Rigidbody2D body;
    private Vector2 moveDirection;

    void Awake()
    {
        playerInput = new PlayerInput();
    }
    private void OnEnable()
    {
        playerInput.Player.Enable();
    }

    private void OnDisable()
    {
        playerInput.Player.Disable();
    }

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        /*var horizontal = Mathf.RoundToInt(playerInput.Player.Move.ReadValue<Vector2>().x);
        var velocityX = speed * horizontal;
        body.velocity = new Vector2(velocityX, body.velocity.y);*/
    }
    private void FixedUpdate()
    {
        body.velocity = moveDirection * speed;
    }
}
