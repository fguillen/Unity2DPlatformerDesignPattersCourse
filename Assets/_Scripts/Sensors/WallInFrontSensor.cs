using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.Physics2D;


namespace Sensors
{
    public class WallInFrontSensor: ObstacleSensor
    {
        public bool wallInFront;

        public bool WallInFront()
        {
            return ObstacleFound();
        }
    }
}
