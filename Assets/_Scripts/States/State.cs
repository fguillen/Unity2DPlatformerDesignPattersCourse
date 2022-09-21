using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class State : MonoBehaviour
{
    public UnityEvent OnEnter, OnExit;
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

        OnEnter?.Invoke();
        EnterState();
    }

    public void Exit()
    {
        this.agent.agentInput.OnAttack -= HandleAttack;
        this.agent.agentInput.OnJumpPressed -= HandleJumpPressed;
        this.agent.agentInput.OnJumpReleased -= HandleJumpReleased;
        this.agent.agentInput.OnWeaponChange -= HandleWeaponChange;

        OnExit?.Invoke();
        ExitState();
    }

    public virtual void HandleMovement(Vector2 movement) {}
    protected virtual void HandleAttack() {}
    protected virtual void HandleJumpPressed() {}
    protected virtual void HandleJumpReleased() {}
    protected virtual void HandleWeaponChange() {}

    public virtual void EnterState() {}
    public virtual void ExitState() {}

    public virtual void StateUpdate() {}
    public virtual void StateFixedUpdate() {}
}
