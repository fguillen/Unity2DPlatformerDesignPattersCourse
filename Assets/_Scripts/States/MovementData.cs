using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementData : MonoBehaviour
{

    public int horizontalMovementDirection { get; private set; }

    private Vector2 _agentMovement;
    public Vector2 agentMovement {
        get => _agentMovement;
        set {
            _agentMovement = value;
            CalculateHorizontalMovementDirection();
        }
    }
    public float currentSpeed;
    public Vector2 currentVelocity;

    void CalculateHorizontalMovementDirection()
    {
        if(agentMovement.x > 0)
            horizontalMovementDirection = 1;
        else if(agentMovement.x < 0)
            horizontalMovementDirection = -1;
    }
}
