using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    protected override void EnterState()
    {
        agent.agentAnimation.PlayAnimation(AnimationType.idle);

        if(agent.groundDetector.isGrounded)
            agent.rb2d.velocity = agent.movementData.currentVelocity;
    }

    public override void HandleMovement(Vector2 movement)
    {
        if(Mathf.Abs(movement.x) > 0)
            agent.TransitionToState(StateType.run);
        else if(Mathf.Abs(movement.y) > 0 && agent.climbDetector.canClimb)
            agent.TransitionToState(StateType.climb);
    }

    protected override void HandleAttack()
    {
        if(agent.weaponManager.CanAttack())
            agent.TransitionToState(StateType.attack);
    }

    public override void StateFixedUpdate()
    {
        if(!agent.groundDetector.isGrounded)
            agent.TransitionToState(StateType.fall);
    }

    protected override void HandleJumpPressed()
    {
        if(agent.groundDetector.isGrounded)
            agent.TransitionToState(StateType.jump);
    }

}
