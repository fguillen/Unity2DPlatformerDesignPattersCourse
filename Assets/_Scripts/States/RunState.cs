using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : State
{
    [SerializeField] float acceleration;
    [SerializeField] float deceleration;
    [SerializeField] float maxSpeed;

    public override void EnterState()
    {
        agent.agentAnimation.PlayAnimation(AnimationType.run);

        agent.movementData.currentSpeed = 0f;
        agent.movementData.currentVelocity = Vector2.zero;
    }

    public override void StateFixedUpdate()
    {
        SetPlayerVelocity();

        if(Mathf.Abs(agent.rb2d.velocity.x) < 0.01f)
            agent.TransitionToState(StateType.idle);
    }

    protected void SetPlayerVelocity()
    {
        CalculateSpeed();
        CalculateVelocity();

        agent.rb2d.velocity = agent.movementData.currentVelocity;
    }

    void CalculateSpeed()
    {
        if(Mathf.Abs(agent.movementData.agentMovement.x) > 0f)
            agent.movementData.currentSpeed += acceleration * Time.deltaTime;
        else
            agent.movementData.currentSpeed -= deceleration * Time.deltaTime;

        agent.movementData.currentSpeed = Mathf.Clamp(agent.movementData.currentSpeed, 0f, maxSpeed);
    }

    void CalculateVelocity()
    {
        agent.movementData.currentVelocity = new Vector2(agent.movementData.horizontalMovementDirection * agent.movementData.currentSpeed, agent.rb2d.velocity.y);
    }
}
