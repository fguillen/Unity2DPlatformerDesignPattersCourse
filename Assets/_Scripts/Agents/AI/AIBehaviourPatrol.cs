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
            Debug.Log($"Perform {aiAgentBrain.agent.wallInFrontSensor.WallInFront()}, {aiAgentBrain.agent.endOfGroundSensor.EndOfGround()}");


            if(
                aiAgentBrain.agent.wallInFrontSensor.WallInFront() ||
                aiAgentBrain.agent.endOfGroundSensor.EndOfGround()
            )
                Turn();

            aiAgentBrain.CallOnMovement(currentMovement);
        }

        void Turn()
        {
            currentMovement *= new Vector2(-1f, 1f);
        }
    }
}
