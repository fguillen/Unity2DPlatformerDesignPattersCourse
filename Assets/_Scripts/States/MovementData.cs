using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementData : MonoBehaviour
{
    public int horizontalMovementDirection { get; private set; }
    public int verticalMovementDirection { get; private set; }

    private Vector2 _agentMovement;
    public Vector2 agentMovement {
        get => _agentMovement;
        set {
            _agentMovement = value;
            CalculateHorizontalMovementDirection();
            CalculateVerticalMovementDirection();
            CalculateAgentMovementAbs();
        }
    }

    public float currentSpeed;
    public Vector2 currentVelocity;
    public Vector2 agentMovementAbs;

    void CalculateHorizontalMovementDirection()
    {
        if(agentMovement.x > 0)
            horizontalMovementDirection = 1;
        else if(agentMovement.x < 0)
            horizontalMovementDirection = -1;
    }

    void CalculateVerticalMovementDirection()
    {
        if(agentMovement.y > 0)
            verticalMovementDirection = 1;
        else if(agentMovement.y < 0)
            verticalMovementDirection = -1;
    }

    void CalculateAgentMovementAbs()
    {
        agentMovementAbs = new Vector2(Mathf.Ceil(agentMovement.x), Mathf.Ceil(agentMovement.y));
    }
}
