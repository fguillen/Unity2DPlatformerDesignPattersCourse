using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sensors
{
    public class PlayerInFrontSensor: ObstacleSensor
    {
        public bool playerInFront;

        public bool PlayerInFront()
        {
            return ObstacleFound();
        }
    }
}
