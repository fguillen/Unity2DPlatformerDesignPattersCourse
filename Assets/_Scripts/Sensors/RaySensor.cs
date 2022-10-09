using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.Physics2D;

namespace Sensors
{
    public class RaySensor : MonoBehaviour
    {
        [SerializeField] bool drawGizmos;
        [SerializeField] Color gizmosColorObstacle = Color.red;
        [SerializeField] Color gizmosColorNoObstacle = Color.blue;
        [SerializeField] LayerMask objectiveLayerMask;
        [SerializeField] Transform limit;
        [SerializeField] float checkIntervalSeconds = 0.1f;

        float lastTimeChecked;

        public RaycastHit2D hit { get; private set; }
        public bool hasHit { get; private set; }

        void Update()
        {
            if(lastTimeChecked + checkIntervalSeconds < Time.time)
                CheckHit();
        }

        void CheckHit()
        {
            // Debug.Log($"CheckObstacle: {Direction()}, {Distance()}");

            lastTimeChecked = Time.time;

            hit =
                Physics2D.Raycast(
                    transform.position,
                    Direction(),
                    Distance(),
                    objectiveLayerMask
                );

            if(hit.collider != null)
                hasHit = true;
            else
                hasHit = false;
        }

        void OnDrawGizmos()
        {
            if(!drawGizmos)
                return;

            if(hasHit)
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
