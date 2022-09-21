using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    protected override void EnterState()
    {
        agent.agentAnimation.PlayAnimation(AnimationType.idle);
        agent.movementData.currentSpeed = 0;
        agent.movementData.currentVelocity = Vector2.zero;
        agent.rb2d.velocity = agent.movementData.currentVelocity;
    }

    public override void HandleMovement(Vector2 movement)
    {
        if(Mathf.Abs(movement.x) > 0)
            agent.TransitionToState(StateType.run);
    }

    public override void StateFixedUpdate()
    {
        if(!agent.groundDetector.isGrounded)
            agent.TransitionToState(StateType.fall);
    }

}
