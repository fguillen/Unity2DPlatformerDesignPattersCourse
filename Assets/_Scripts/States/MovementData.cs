using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementData : MonoBehaviour
{
    public float currentSpeed;
    public Vector2 currentVelocity;
    public Vector2 movementLastDirection { get; private set; }
    public Vector2 movementDirectionNormalized { get; private set; }

    private Vector2 _agentMovement;
    public Vector2 agentMovement {
        get => _agentMovement;
        set {
            _agentMovement = value;
            CalculateMovementLastDirection();
            CalculateMovementDirectionNormalized();
        }
    }

    void CalculateMovementLastDirection()
    {
        float x = movementLastDirection.x;
        float y = movementLastDirection.y;

        if(agentMovement.x > 0)
            x = 1;
        else if(agentMovement.x < 0)
            x = -1;

        if(agentMovement.y > 0)
            y = 1;
        else if(agentMovement.y < 0)
            y = -1;

        movementLastDirection = new Vector2(x, y);
    }

    void CalculateMovementDirectionNormalized()
    {
        movementDirectionNormalized = new Vector2(agentMovement.x, agentMovement.y).normalized;
    }
}
