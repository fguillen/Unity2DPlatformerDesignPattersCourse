using System;
using UnityEngine;


namespace AI
{
    public abstract class AIAgentBrainPatrolling : AIAgentBrain
    {
        AIBehaviour attackBehaviour;
        AIBehaviour patrolBehaviour;

        void Update()
        {
            if(agent.groundDetector.isGrounded)
            {
                attackBehaviour.Perform(this);
                patrolBehaviour.Perform(this);
            }
        }
    }
}
