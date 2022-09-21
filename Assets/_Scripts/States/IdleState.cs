using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    public override void EnterState()
    {
        agent.agentAnimation.PlayAnimation(AnimationType.idle);
    }

    public override void HandleMovement(Vector2 movement)
    {
        if(Mathf.Abs(movement.x) > 0)
            agent.TransitionToState(StateType.run);
    }

}
