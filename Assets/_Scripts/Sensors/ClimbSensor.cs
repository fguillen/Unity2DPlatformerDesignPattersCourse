using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sensors
{
    public class ClimbSensor : MonoBehaviour
    {
        [SerializeField] LayerMask climbLayerMask;
        bool _canClimb;
        public bool canClimb
        {
            get { return _canClimb; }
            private set { SetCanClimb(value); }
        }

        void OnTriggerEnter2D(Collider2D collision)
        {
            if(InLayerMask(collision.gameObject.layer))
                canClimb = true;
        }

        void OnTriggerExit2D(Collider2D collision)
        {
            if(InLayerMask(collision.gameObject.layer))
                canClimb = false;
        }

        bool InLayerMask(int layer)
        {
            return climbLayerMask == (climbLayerMask | (1 << layer));
        }

        void SetCanClimb(bool value)
        {
            Debug.Log($"CanClimb: {value}");
            _canClimb = value;
        }
    }
}
