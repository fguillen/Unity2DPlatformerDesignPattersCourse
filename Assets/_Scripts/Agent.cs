using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerSpawn;
using WeaponSystem;

public class Agent : MonoBehaviour
{
    [HideInInspector] public Rigidbody2D rb2d;
    [HideInInspector] public PlayerInput agentInput;
    [HideInInspector] public AgentAnimation agentAnimation;
    [HideInInspector] public GroundDetector groundDetector;
    [HideInInspector] public ClimbDetector climbDetector;
    [HideInInspector] public WeaponManager weaponManager;
    AgentRenderer agentRenderer;

    [SerializeField] State currentState;

    State idleState;
    State runState;
    State jumpState;
    State fallState;
    State climbState;
    State attackState;
    [SerializeField] public MovementData movementData;
    [SerializeField] public AgentDataSO agentData;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        agentInput = GetComponentInParent<PlayerInput>();
        agentAnimation = GetComponentInChildren<AgentAnimation>();
        agentRenderer = GetComponentInChildren<AgentRenderer>();
        groundDetector = GetComponentInChildren<GroundDetector>();
        climbDetector = GetComponentInChildren<ClimbDetector>();

        weaponManager = GetComponentInChildren<WeaponManager>();
        weaponManager.Initialize(this);

        idleState = GetComponentInChildren<IdleState>();
        runState = GetComponentInChildren<RunState>();
        jumpState = GetComponentInChildren<JumpState>();
        fallState = GetComponentInChildren<FallState>();
        climbState = GetComponentInChildren<ClimbState>();
        attackState = GetComponentInChildren<AttackState>();

        idleState.InitializeState(this);
        runState.InitializeState(this);
        jumpState.InitializeState(this);
        fallState.InitializeState(this);
        climbState.InitializeState(this);
        attackState.InitializeState(this);
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

        TransitionToState(StateType.idle);
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

            case StateType.climb:
                currentState = climbState;
                break;

            case StateType.attack:
                currentState = attackState;
                break;

            default:
                break;
        }

        currentState?.Enter();
    }

    void HandleMovement(Vector2 movement)
    {
        movementData.agentMovement = movement;
        currentState.HandleMovement(movement);
    }

    public void Die()
    {
        PlayerSpawnManager.instance.SpawnPlayer();
    }
}
