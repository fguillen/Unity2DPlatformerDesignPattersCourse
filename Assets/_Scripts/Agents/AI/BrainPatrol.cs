using System;
using UnityEngine;


namespace AI
{
    public class BrainPatrol : AgentBrain
    {
        [SerializeField] AgentBehaviour attackBehaviour;
        [SerializeField] AgentBehaviour patrolBehaviour;

        void Update()
        {
            if(agent.groundSensor.isGrounded)
            {
                attackBehaviour.Perform(agent);
                patrolBehaviour.Perform(agent);
            }
        }
    }
}
