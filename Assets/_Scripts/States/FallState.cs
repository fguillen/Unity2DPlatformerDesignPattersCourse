using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FallState : RunState
{
    public UnityEvent OnLand;

    public override StateType Type()
    {
        return StateType.Fall;
    }

    protected override void EnterState()
    {
        agent.agentAnimation.PlayAnimation(AnimationType.fall);
    }

    protected override void ExitState()
    {
        if(agent.groundSensor.isGrounded)
            OnLand?.Invoke();
    }


    public override void StateUpdate()
    {
        if(agent.climbSensor.canClimb && agent.movementData.agentMovementAbs.y > 0)
            agent.stateManager.TransitionToState(StateType.Climb);
    }

    public override void StateFixedUpdate()
    {
        ApplyFallForce();
        SetPlayerVelocity();

        if(agent.groundSensor.isGrounded)
            agent.stateManager.TransitionToState(StateType.Idle);
    }

    void ApplyFallForce()
    {
        agent.rb2d.AddForce(Vector2.down * agent.agentData.fallForce, ForceMode2D.Force);
    }

    protected override void HandleHit()
    {
        agent.stateManager.TransitionToState(StateType.Hit);
    }
}
