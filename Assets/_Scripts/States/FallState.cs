using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallState : RunState
{
    public override void EnterState()
    {
        agent.agentAnimation.PlayAnimation(AnimationType.fall);
    }

    public override void StateFixedUpdate()
    {
        SetPlayerVelocity();

        if(agent.groundDetector.isGrounded)
            agent.TransitionToState(StateType.idle);
    }
}
