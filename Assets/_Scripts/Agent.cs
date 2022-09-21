using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    [HideInInspector] public Rigidbody2D rb2d;
    [HideInInspector] public PlayerInput agentInput;
    [HideInInspector] public AgentAnimation agentAnimation;
    [HideInInspector] public GroundDetector groundDetector;
    AgentRenderer agentRenderer;

    [SerializeField] State currentState;

    [SerializeField] State idleState;
    [SerializeField] State runState;
    [SerializeField] State jumpState;
    [SerializeField] State fallState;
    [SerializeField] public MovementData movementData;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        agentInput = GetComponentInParent<PlayerInput>();
        agentAnimation = GetComponentInChildren<AgentAnimation>();
        agentRenderer = GetComponentInChildren<AgentRenderer>();
        groundDetector = GetComponentInChildren<GroundDetector>();

        idleState.InitializeState(this);
        runState.InitializeState(this);
        jumpState.InitializeState(this);
        fallState.InitializeState(this);

        TransitionToState(StateType.idle);
    }

    void Update()
    {
        currentState?.StateUpdate();
    }

    void FixedUpdate()
    {
        groundDetector.DetectGrounded();
        currentState?.StateFixedUpdate();
    }

    // Start is called before the first frame update
    void Start()
    {
        agentInput.OnMovement += HandleMovement;
        agentInput.OnMovement += agentRenderer.FaceDirection;
        agentInput.OnJumpPressed += HandleJumpPressed;
    }

    public void TransitionToState(StateType stateType)
    {
        Debug.Log($"TransitionToState({stateType.ToString()})");

        currentState?.Exit();

        switch (stateType)
        {
            case StateType.idle:
                currentState = idleState;
                break;

            case StateType.run:
                currentState = runState;
                break;

            case StateType.jump:
                currentState = jumpState;
                break;

            case StateType.fall:
                currentState = fallState;
                break;

            default:
                break;
        }

        currentState.Enter();
    }

    void HandleMovement(Vector2 movement)
    {
        movementData.agentMovement = movement;
        currentState.HandleMovement(movement);
    }

    void HandleJumpPressed()
    {
        if(groundDetector.isGrounded)
            TransitionToState(StateType.jump);
    }
}
