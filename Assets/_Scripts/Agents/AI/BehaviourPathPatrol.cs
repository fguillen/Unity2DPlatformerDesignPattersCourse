using UnityEngine;


namespace AI
{
    public class BehaviourPathPatrol : AgentBehaviour
    {
        [SerializeField] Path path;
        [SerializeField] float distanceToPoint = 0.5f;
        [SerializeField] float waitingTime;

        Vector2 currentPoint;
        bool isInitialized = false;
        bool isWaiting = false;
        Agent agent;

        public override void Perform(Agent agent)
        {
            if(!isInitialized)
                Initialize(agent);

            if(isWaiting)
                return;

            MoveToCurrentPoint();

            if(CheckIfArriveToPoint())
                ArrivedToPoint();
        }

        void Initialize(Agent agent)
        {
            this.agent = agent;
            currentPoint = path.ClosestPoint(agent.transform.position);
            isInitialized = true;
        }

        bool CheckIfArriveToPoint()
        {
            return (currentPoint - (Vector2)agent.transform.position).magnitude < distanceToPoint;
        }

        void ArrivedToPoint()
        {
            isWaiting = true;
            agent.agentInput.CallMovement(Vector2.zero);
            Invoke("EndWaiting", waitingTime);
        }

        void EndWaiting()
        {
            isWaiting = false;
            NextPoint();
        }

        void MoveToCurrentPoint()
        {
            Vector2 direction = (currentPoint - (Vector2)agent.transform.position).normalized;
            if(agent.movementData.agentMovement != direction)
                agent.agentInput.CallMovement(direction);
        }

        void NextPoint()
        {
            currentPoint = path.NextPoint(currentPoint);
        }
    }
}
