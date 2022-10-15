using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementData : MonoBehaviour
{
    public float currentSpeed;
    public Vector2 currentVelocity;
    public Vector2 movementDirectionRounded { get; private set; }
    public Vector2 movementDirectionNormalized { get; private set; }

    private Vector2 _agentMovement;
    public Vector2 agentMovement {
        get => _agentMovement;
        set {
            _agentMovement = value;
            CalculateMovementDirectionRounded();
            CalculateMovementDirectionNormalized();
        }
    }

    void CalculateMovementDirectionRounded()
    {
        movementDirectionRounded = new Vector2(Mathf.RoundToInt(agentMovement.x), Mathf.RoundToInt(agentMovement.y));
    }

    void CalculateMovementDirectionNormalized()
    {
        movementDirectionNormalized = new Vector2(agentMovement.x, agentMovement.y).normalized;
    }
}
