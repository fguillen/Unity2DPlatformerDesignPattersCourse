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
            if(agent.groundSensor.isGrounded)
            {
                attackBehaviour.Perform(this);
                patrolBehaviour.Perform(this);
            }
        }
    }
}
