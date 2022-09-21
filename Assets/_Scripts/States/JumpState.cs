using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : RunState
{
    [SerializeField] float jumpForce;

    public override void EnterState()
    {
        agent.agentAnimation.PlayAnimation(AnimationType.jump);
        agent.rb2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    public override void StateFixedUpdate()
    {
        SetPlayerVelocity();

        if(agent.rb2d.velocity.y < 0)
            agent.TransitionToState(StateType.fall);
    }
}
