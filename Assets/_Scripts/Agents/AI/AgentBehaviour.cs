using System;
using UnityEngine;


namespace AI
{
    public abstract class AgentBehaviour : MonoBehaviour
    {
        public abstract void Perform(Agent agent);
    }
}
