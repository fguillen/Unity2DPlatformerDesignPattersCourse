using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    Rigidbody2D rb2d;
    PlayerInput playerInput;
    AgentAnimation agentAnimation;
    AgentRenderer agentRenderer;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        playerInput = GetComponentInParent<PlayerInput>();
        agentAnimation = GetComponentInChildren<AgentAnimation>();
        agentRenderer = GetComponentInChildren<AgentRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        playerInput.OnMovement += HandleMovement;
        playerInput.OnMovement += agentRenderer.FaceDirection;
    }

    void HandleMovement(Vector2 movement)
    {
        if(Mathf.Abs(movement.x) > 0.01f)
            agentAnimation.PlayAnimation(AnimationType.run);
        else
            agentAnimation.PlayAnimation(AnimationType.idle);

        rb2d.velocity = new Vector2(movement.x * 5f, rb2d.velocity.y);
    }
}
