using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.Physics2D;

namespace Sensors
{
    public class EndOfGroundSensor : ObstacleSensor
    {
        public bool endOfGround;

        public bool EndOfGround()
        {
            return ObstacleFound();
        }
    }
}
