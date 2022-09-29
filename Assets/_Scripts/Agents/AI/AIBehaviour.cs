using System;
using UnityEngine;


namespace AI
{
    public abstract class AIBehaviour : MonoBehaviour
    {
        public abstract void Perform(AIAgentBrain aiAgentBrain);
    }
}
