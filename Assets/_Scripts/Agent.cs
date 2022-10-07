using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerSpawn;
using WeaponSystem;
using Sensors;

public class Agent : MonoBehaviour
{
    [HideInInspector] public Rigidbody2D rb2d;
    [HideInInspector] public IAgentInput agentInput;
    [HideInInspector] public AgentAnimation agentAnimation;
    [HideInInspector] public GroundSensor groundSensor;
    [HideInInspector] public ClimbSensor climbSensor;
    [HideInInspector] public WallInFrontSensor wallInFrontSensor;
    [HideInInspector] public PlayerInFrontSensor playerInFrontSensor;
    [HideInInspector] public EndOfGroundSensor endOfGroundSensor;
    [HideInInspector] public WeaponManager weaponManager;
    [HideInInspector] public StateManager stateManager;
    [HideInInspector] public DamageManager damageManager;

    SpriteFlipper spriteFlipper;

    [SerializeField] public MovementData movementData;
    [SerializeField] public AgentDataSO agentData;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        agentInput = GetComponentInParent<IAgentInput>();
        agentAnimation = GetComponentInChildren<AgentAnimation>();
        spriteFlipper = GetComponentInChildren<SpriteFlipper>();
        groundSensor = GetComponentInChildren<GroundSensor>();
        climbSensor = GetComponentInChildren<ClimbSensor>();
        wallInFrontSensor = GetComponentInChildren<WallInFrontSensor>();
        playerInFrontSensor = GetComponentInChildren<PlayerInFrontSensor>();
        endOfGroundSensor = GetComponentInChildren<EndOfGroundSensor>();

        weaponManager = GetComponentInChildren<WeaponManager>();
        weaponManager.Initialize(this);

        stateManager = GetComponentInChildren<StateManager>();
        stateManager.Initialize(this);

        damageManager = GetComponentInChildren<DamageManager>();
        damageManager.Initialize(agentData.maxHealth);
    }

    // Start is called before the first frame update
    void Start()
    {
        agentInput.OnMovement += HandleMovement;
        agentInput.OnMovement += spriteFlipper.FaceDirection;
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
