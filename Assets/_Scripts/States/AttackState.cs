using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    protected override void EnterState()
    {
        agent.agentAnimation.PlayAnimation(AnimationType.attack);
    }

    protected override void HandleAnimationAction()
    {
        agent.weaponManager.Attack();
    }

    protected override void HandleAnimationEnd()
    {
        agent.TransitionToState(StateType.idle);
    }
}
