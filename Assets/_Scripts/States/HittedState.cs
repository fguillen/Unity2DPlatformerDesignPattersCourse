using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HittedState : State
{
    public UnityEvent OnHit;

    public override StateType Type()
    {
        return StateType.Hit;
    }

    protected override void EnterState()
    {
        agent.agentAnimation.PlayAnimation(AnimationType.hit);
        OnHit?.Invoke();
    }

    protected override void HandleAnimationEnd()
    {
        Debug.Log("HittedState.HandleAnimationEnd()");

        agent.stateManager.TransitionToState(StateType.Idle);
    }
}
