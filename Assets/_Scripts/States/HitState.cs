using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HitState : State
{
    public UnityEvent OnHit;

    public override StateType Type()
    {
        return StateType.Hit;
    }

    protected override void EnterState()
    {
        agent.agentAnimation.PlayAnimation(AnimationType.hit);
        agent.rb2d.velocity = new Vector2(0f, agent.rb2d.velocity.y);
        OnHit?.Invoke();
    }

    protected override void HandleAnimationEnd()
    {
        agent.stateManager.TransitionToState(StateType.Idle);
    }
}
