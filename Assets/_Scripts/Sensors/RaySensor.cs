using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.Physics2D;

namespace Sensors
{
    public class RaySensor : MonoBehaviour
    {
        public bool obstacleFound;

        [SerializeField] bool drawGizmos;
        [SerializeField] Color gizmosColorObstacle = Color.red;
        [SerializeField] Color gizmosColorNoObstacle = Color.blue;
        [SerializeField] LayerMask groundLayerMask;
        [SerializeField] Transform limit;

        public RaycastHit2D hit { get; private set; }

        public bool ObstacleFound()
        {
            CheckObstacle();
            return obstacleFound;
        }

        void CheckObstacle()
        {
            // Debug.Log($"CheckObstacle: {Direction()}, {Distance()}");

            hit =
                Physics2D.Raycast(
                    transform.position,
                    Direction(),
                    Distance(),
                    groundLayerMask
                );

            if(hit.collider != null)
                obstacleFound = true;
            else
                obstacleFound = false;
        }

        void OnDrawGizmos()
        {
            if(!drawGizmos)
                return;

            CheckObstacle();

            if(obstacleFound)
                Gizmos.color = gizmosColorObstacle;
            else
                Gizmos.color = gizmosColorNoObstacle;

            Gizmos.DrawLine(transform.position, limit.position);
        }

        Vector3 Direction()
        {
            return (limit.position - transform.position).normalized;
        }

        float Distance()
        {
            return Mathf.Abs((transform.position - limit.position).magnitude);
        }
    }
}
