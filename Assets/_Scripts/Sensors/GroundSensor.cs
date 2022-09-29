using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Sensors
{
    public class GroundSensor : MonoBehaviour
    {
        List<ObstacleSensor> obstacleSensors;
        Collider2D insideCollider;

        public bool isGrounded { get; private set; }

        void Awake()
        {
            obstacleSensors = GetComponentsInChildren<ObstacleSensor>().ToList();
            insideCollider = GetComponent<Collider2D>();
        }

        public void DetectGrounded()
        {
            isGrounded = false;

            foreach (var obstacleSensor in obstacleSensors)
            {
                if(obstacleSensor.ObstacleFound() && !obstacleSensor.hit.collider.IsTouching(insideCollider))
                {
                    isGrounded = true;
                    break;
                }
            }
        }
    }
}
