using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallState : RunState
{
    [SerializeField] float fallForce = 0f;

    protected override void EnterState()
    {
        agent.agentAnimation.PlayAnimation(AnimationType.fall);
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
        agent.rb2d.AddForce(Vector2.down * fallForce, ForceMode2D.Force);
    }
}
