using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    public override StateType Type()
    {
        return StateType.Idle;
    }

    protected override void EnterState()
    {
        agent.agentAnimation.PlayAnimation(AnimationType.idle);

        if(agent.groundSensor.isGrounded)
            agent.rb2d.velocity = Vector2.zero;
    }

    protected override void HandleMovement(Vector2 movement)
    {
        if(Mathf.Abs(movement.x) > 0)
            agent.stateManager.TransitionToState(StateType.Run);
        else if(Mathf.Abs(movement.y) > 0 && agent.climbSensor.canClimb)
            agent.stateManager.TransitionToState(StateType.Climb);
    }

    protected override void HandleAttack()
    {
        if(agent.weaponManager.CanAttack())
            agent.stateManager.TransitionToState(StateType.Attack);
    }

    public override void StateFixedUpdate()
    {
        if(!agent.groundSensor.isGrounded)
            agent.stateManager.TransitionToState(StateType.Fall);
    }

    protected override void HandleJumpPressed()
    {
        if(agent.groundSensor.isGrounded)
            agent.stateManager.TransitionToState(StateType.Jump);
    }

    protected override void HandleHit()
    {
        Debug.Log("IdleState.HandleHit()");

        agent.stateManager.TransitionToState(StateType.Hit);
    }
}
