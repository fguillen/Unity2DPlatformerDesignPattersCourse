using UnityEngine;


namespace AI
{
    public class BehaviourPatrol : AgentBehaviour
    {
        Vector2 currentMovement;


        public override void Perform(Agent agent)
        {
            if(currentMovement == Vector2.zero)
                InitCurrentMovement();

            if(
                agent.wallInFrontSensor.hasHit ||
                !agent.endOfGroundSensor.hasHit
            )
                Turn();

            agent.agentInput.CallMovement(currentMovement);
        }

        void InitCurrentMovement()
        {
            currentMovement = new Vector2((Random.value > 0.5f ? 1f : -1f), 0f);
        }

        void Turn()
        {
            currentMovement *= new Vector2(-1f, 1f);
        }
    }
}
