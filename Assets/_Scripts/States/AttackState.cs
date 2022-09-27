using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AttackState : State
{
    public UnityEvent OnAttack;

    public override StateType Type()
    {
        return StateType.Attack;
    }

    protected override void EnterState()
    {
        agent.agentAnimation.PlayAnimation(AnimationType.attack);
        agent.rb2d.velocity = Vector2.zero;
    }

    protected override void HandleAnimationAction()
    {
        agent.weaponManager.Attack();
        OnAttack?.Invoke();
    }

    protected override void HandleAnimationEnd()
    {
        agent.stateManager.TransitionToState(StateType.Idle);
    }
}
