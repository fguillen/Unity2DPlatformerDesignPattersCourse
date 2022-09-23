using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbState : State
{
    float previousGravityScale;



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
            agent.TransitionToState(StateType.idle);
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


}
