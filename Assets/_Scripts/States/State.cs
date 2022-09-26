using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class State : MonoBehaviour
{
    protected Agent agent;

    public void InitializeState(Agent agent)
    {
        this.agent = agent;
    }

    public void Enter()
    {
        this.agent.agentInput.OnAttack += HandleAttack;
        this.agent.agentInput.OnJumpPressed += HandleJumpPressed;
        this.agent.agentInput.OnJumpReleased += HandleJumpReleased;
        this.agent.agentInput.OnWeaponChange += HandleWeaponChange;

        this.agent.agentAnimation.OnAnimationAction += HandleAnimationAction;
        this.agent.agentAnimation.OnAnimationEnd += HandleAnimationEnd;

        EnterState();
    }

    public void Exit()
    {
        this.agent.agentInput.OnAttack -= HandleAttack;
        this.agent.agentInput.OnJumpPressed -= HandleJumpPressed;
        this.agent.agentInput.OnJumpReleased -= HandleJumpReleased;
        this.agent.agentInput.OnWeaponChange -= HandleWeaponChange;

        this.agent.agentAnimation.OnAnimationAction -= HandleAnimationAction;
        this.agent.agentAnimation.OnAnimationEnd -= HandleAnimationEnd;

        ExitState();
    }

    public virtual void HandleMovement(Vector2 movement) {}
    protected virtual void HandleAttack() {}
    protected virtual void HandleJumpPressed() {}
    protected virtual void HandleJumpReleased() {}
    protected virtual void HandleWeaponChange() {}

    protected virtual void EnterState() {}
    protected virtual void ExitState() {}

    protected virtual void HandleAnimationAction() {}
    protected virtual void HandleAnimationEnd() {}

    public virtual void StateUpdate() {}
    public virtual void StateFixedUpdate() {}
}
