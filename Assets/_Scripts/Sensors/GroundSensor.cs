using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Sensors
{
    public class GroundSensor : MonoBehaviour
    {
        List<RaySensor> RaySensors;
        Collider2D insideCollider;

        public bool isGrounded { get; private set; }

        void Awake()
        {
            RaySensors = GetComponentsInChildren<RaySensor>().ToList();
            insideCollider = GetComponent<Collider2D>();
        }

        public void DetectGrounded()
        {
            isGrounded = false;

            foreach (var RaySensor in RaySensors)
            {
                if(RaySensor.ObstacleFound() && !RaySensor.hit.collider.IsTouching(insideCollider))
                {
                    isGrounded = true;
                    break;
                }
            }
        }
    }
}
