using UnityEngine;

namespace AI
{
    public class AIBehaviourAttack : AIBehaviour
    {
        Vector2 currentMovement;

        float lastAttackAt = 0;
        [SerializeField] float delayBetweenAttacks = 1f;

        void Start()
        {
            currentMovement = new Vector2((Random.value > 0.5f ? 1f : -1f), 0f);
        }

        public override void Perform(AIAgentBrain aiAgentBrain)
        {
            if(lastAttackAt + delayBetweenAttacks > Time.time)
                return;

            if(aiAgentBrain.agent.playerInFrontSensor.hasHit)
            {
                aiAgentBrain.CallAttack();
                lastAttackAt = Time.time;
            }
        }
    }
}
