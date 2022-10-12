using System;
using UnityEngine;


namespace AI
{
    public class BrainShooter : AgentBrain
    {
        [SerializeField] BehaviourAttackWhenPlayerInArea behaviourAttackWhenPlayerInArea;

        void Update()
        {
            behaviourAttackWhenPlayerInArea.Perform(agent);
        }
    }
}
