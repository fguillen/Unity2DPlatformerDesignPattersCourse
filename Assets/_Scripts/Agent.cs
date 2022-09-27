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
    [HideInInspector] public StateManager stateManager;
    [HideInInspector] public DamageManager damageManager;

    AgentRenderer agentRenderer;

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

        stateManager = GetComponentInChildren<StateManager>();
        stateManager.Initialize(this);

        damageManager = GetComponentInChildren<DamageManager>();
        damageManager.Initialize(agentData.maxHealth);
    }

    void Update()
    {
        stateManager.currentState?.StateUpdate();
    }

    void FixedUpdate()
    {
        groundDetector.DetectGrounded();
        stateManager.currentState?.StateFixedUpdate();
    }

    // Start is called before the first frame update
    void Start()
    {
        agentInput.OnMovement += HandleMovement;
        agentInput.OnMovement += agentRenderer.FaceDirection;
        Initialize();
    }

    void HandleMovement(Vector2 movement)
    {
        movementData.agentMovement = movement;
    }

    public void Die()
    {
        PlayerSpawnManager.instance.SpawnPlayer();
    }

    public void Initialize()
    {
        stateManager.TransitionToState(StateType.Idle);
    }
}
