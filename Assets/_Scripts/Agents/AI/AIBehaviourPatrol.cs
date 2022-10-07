using UnityEngine;


namespace AI
{
    public class AIBehaviourPatrol : AIBehaviour
    {
        Vector2 currentMovement;

        void Start()
        {
            currentMovement = new Vector2((Random.value > 0.5f ? 1f : -1f), 0f);
        }

        public override void Perform(AIAgentBrain aiAgentBrain)
        {
            if(
                aiAgentBrain.agent.wallInFrontSensor.hasHit ||
                !aiAgentBrain.agent.endOfGroundSensor.hasHit
            )
                Turn();

            aiAgentBrain.CallMovement(currentMovement);
        }

        void Turn()
        {
            currentMovement *= new Vector2(-1f, 1f);
        }
    }
}
