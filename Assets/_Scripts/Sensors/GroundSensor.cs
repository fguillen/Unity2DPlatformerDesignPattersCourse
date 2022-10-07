using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Sensors
{
    public class GroundSensor : MonoBehaviour
    {
        public bool isGrounded { get; private set; }

        [SerializeField] float checkIntervalSeconds = 0.1f;

        List<RaySensor> RaySensors;
        Collider2D insideCollider;
        float lastTimeChecked;

        void Update()
        {
            if(lastTimeChecked + checkIntervalSeconds < Time.time)
                CheckGrounded();
        }

        void Awake()
        {
            RaySensors = GetComponentsInChildren<RaySensor>().ToList();
            insideCollider = GetComponent<Collider2D>();
        }

        void CheckGrounded()
        {
            lastTimeChecked = Time.time;
            isGrounded = false;

            foreach (var RaySensor in RaySensors)
            {
                if(RaySensor.hasHit && !RaySensor.hit.collider.IsTouching(insideCollider))
                {
                    isGrounded = true;
                    break;
                }
            }
        }
    }
}
