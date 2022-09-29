using System;
using UnityEngine;


namespace AI
{
    public class AIAgentBrainPatrol : AIAgentBrain
    {
        [SerializeField] AIBehaviour attackBehaviour;
        [SerializeField] AIBehaviour patrolBehaviour;

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
