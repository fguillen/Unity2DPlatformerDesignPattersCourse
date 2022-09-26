using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FallState : RunState
{
    public UnityEvent OnLand;

    protected override void EnterState()
    {
        agent.agentAnimation.PlayAnimation(AnimationType.fall);
    }

    protected override void ExitState()
    {
        if(agent.groundDetector.isGrounded)
            OnLand?.Invoke();
    }


    public override void StateUpdate()
    {
        if(agent.climbDetector.canClimb && agent.movementData.agentMovementAbs.y > 0)
            agent.TransitionToState(StateType.climb);
    }

    public override void StateFixedUpdate()
    {
        ApplyFallForce();
        SetPlayerVelocity();

        if(agent.groundDetector.isGrounded)
            agent.TransitionToState(StateType.idle);
    }

    void ApplyFallForce()
    {
        agent.rb2d.AddForce(Vector2.down * agent.agentData.fallForce, ForceMode2D.Force);
    }
}
