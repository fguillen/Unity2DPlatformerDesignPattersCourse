using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbState : State
{
    float previousGravityScale;

    public override StateType Type()
    {
        return StateType.Climb;
    }

    protected override void EnterState()
    {
        Debug.Log("ClimbState.EnterState()");

        agent.agentAnimation.PlayAnimation(AnimationType.climb);

        agent.movementData.currentSpeed = 0f;
        agent.movementData.currentVelocity = Vector2.zero;

        previousGravityScale = agent.rb2d.gravityScale;
        agent.rb2d.gravityScale = 0f;
    }

    protected override void ExitState()
    {
        agent.rb2d.gravityScale = previousGravityScale;
    }

    public override void StateFixedUpdate()
    {
        if(!agent.climbDetector.canClimb)
        {
            agent.stateManager.TransitionToState(StateType.Idle);
            return;
        }

        SetPlayerVelocity();
    }

    protected void SetPlayerVelocity()
    {
        CalculateVelocity();

        agent.rb2d.velocity = agent.movementData.currentVelocity;
    }

    void CalculateVelocity()
    {
        agent.movementData.currentVelocity =
            new Vector2(
                agent.movementData.agentMovementAbs.x * agent.agentData.climbSpeed,
                agent.movementData.agentMovementAbs.y * agent.agentData.climbSpeed
            );
    }

    protected override void HandleJumpPressed()
    {
        agent.stateManager.TransitionToState(StateType.Jump);
    }


}