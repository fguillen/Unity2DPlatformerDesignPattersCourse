using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    Rigidbody2D rb2d;
    PlayerInput playerInput;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        playerInput = GetComponentInParent<PlayerInput>();
    }

    // Start is called before the first frame update
    void Start()
    {
        playerInput.OnMovement += HandleMovement;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void HandleMovement(Vector2 movement)
    {
        rb2d.velocity = new Vector2(movement.x * 5f, rb2d.velocity.y);
    }
}
