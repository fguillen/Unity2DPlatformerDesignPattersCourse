using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DieState : State
{
    public UnityEvent OnDie;

    public override StateType Type()
    {
        return StateType.Die;
    }

    protected override void EnterState()
    {
        agent.agentAnimation.PlayAnimation(AnimationType.die);
        agent.rb2d.velocity = new Vector2(0f, agent.rb2d.velocity.y);

        OnDie?.Invoke();
    }

    protected override void HandleAnimationEnd()
    {
        agent.Die();
    }
}
