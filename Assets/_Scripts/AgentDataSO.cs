using UnityEngine;

[CreateAssetMenu(fileName = "AgentData", menuName = "Agent/AgentData")]
public class AgentDataSO : ScriptableObject
{
    [Header("Movement Data")]
    [Space]
    public float maxSpeed = 6f;
    public float acceleration = 50f;
    public float deceleration = 50f;

    [Header("Jump Data")]
    [Space]
    public float jumpForce = 12f;
    public float lowJumpForce = 50f;
    public float fallForce = 50f;

    [Header("Climb Data")]
    [Space]
    public float climbSpeed = 4f;
}
