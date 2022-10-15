using System;
using UnityEngine;


namespace AI
{
    public class BrainBat : AgentBrain
    {
        [SerializeField] AgentBehaviour attackBehaviour;
        [SerializeField] AgentBehaviour patrolBehaviour;

        void Update()
        {
            attackBehaviour.Perform(agent);
            patrolBehaviour.Perform(agent);
        }
    }
}
