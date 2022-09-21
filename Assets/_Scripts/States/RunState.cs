using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : State
{
    protected MovementData movementData;
    [SerializeField] float acceleration;
    [SerializeField] float deceleration;
    [SerializeField] float maxSpeed;

    void Awake()
    {
        movementData = GetComponent<MovementData>();
    }

    public override void EnterState()
    {
        agent.agentAnimation.PlayAnimation(AnimationType.run);

        movementData.currentSpeed = 0f;
        movementData.currentVelocity = Vector2.zero;
    }

    public override void StateUpdate()
    {
        SetPlayerVelocity();

        if(Mathf.Abs(agent.rb2d.velocity.x) < 0.01f)
            agent.TransitionToState(StateType.idle);
    }

    void CalculateVelocity()
    {
        movementData.currentVelocity = new Vector2(movementData.horizontalMovementDirection * movementData.currentSpeed, agent.rb2d.velocity.y);
    }

    void SetPlayerVelocity()
    {
        CalculateSpeed();
        CalculateVelocity();

        agent.rb2d.velocity = movementData.currentVelocity;
    }

    void CalculateSpeed()
    {
        if(Mathf.Abs(movementData.agentMovement.x) > 0f)
            movementData.currentSpeed += acceleration * Time.deltaTime;
        else
            movementData.currentSpeed -= deceleration * Time.deltaTime;

        movementData.currentSpeed = Mathf.Clamp(movementData.currentSpeed, 0f, maxSpeed);
    }

}
