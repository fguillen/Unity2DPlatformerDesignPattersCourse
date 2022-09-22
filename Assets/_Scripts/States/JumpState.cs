using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : RunState
{
    bool jumpPressed = false;

    protected override void EnterState()
    {
        agent.agentAnimation.PlayAnimation(AnimationType.jump);
        agent.rb2d.AddForce(Vector2.up * agent.agentData.jumpForce, ForceMode2D.Impulse);
        jumpPressed = true;

        Debug.Log($"EnterState {jumpPressed}");
    }

    public override void StateFixedUpdate()
    {
        ApplyLowJumpModifier();
        SetPlayerVelocity();

        if(agent.rb2d.velocity.y < 0)
        {
            agent.rb2d.velocity = new Vector2(agent.rb2d.velocity.x, 0f);
            agent.TransitionToState(StateType.fall);
        }
    }

    void ApplyLowJumpModifier()
    {
        Debug.Log($"ApplyLowJumpModifier {jumpPressed}");

        if(!jumpPressed)
            agent.rb2d.AddForce(Vector2.down * agent.agentData.lowJumpForce, ForceMode2D.Force);
    }

    protected override void HandleJumpReleased()
    {
        Debug.Log($"HandleJumpReleased()");
        jumpPressed = false;
    }


}
