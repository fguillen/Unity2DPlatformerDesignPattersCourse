using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeaponSystem;
using Sensors;

public class Agent : MonoBehaviour
{
    [HideInInspector] public Rigidbody2D rb2d;
    [HideInInspector] public AgentInput agentInput;
    [HideInInspector] public AgentAnimation agentAnimation;
    [HideInInspector] public GroundSensor groundSensor;
    [HideInInspector] public ClimbSensor climbSensor;
    [HideInInspector] public WallInFrontSensor wallInFrontSensor;
    [HideInInspector] public PlayerInFrontSensor playerInFrontSensor;
    [HideInInspector] public EndOfGroundSensor endOfGroundSensor;
    [HideInInspector] public WeaponManager weaponManager;
    [HideInInspector] public StateManager stateManager;
    [HideInInspector] public DamageManager damageManager;
    [HideInInspector] public RespawnManager respawnManager;

    SpriteFlipper spriteFlipper;

    [SerializeField] public MovementData movementData;
    [SerializeField] public AgentDataSO agentData;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        agentInput = GetComponentInParent<AgentInput>();
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
        damageManager.Initialize(this, agentData.maxHealth);

        respawnManager = GetComponentInChildren<RespawnManager>();
        if(respawnManager != null)
            respawnManager.Initialize(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        agentInput.OnMovement += HandleMovement;
        agentInput.OnMovement += spriteFlipper.FaceDirection;
        agentInput.OnWeaponChange += weaponManager.HandleWeaponChange;
        Initialize();
    }

    void HandleMovement(Vector2 movement)
    {
        movementData.agentMovement = movement;
    }

    public void Die()
    {
        Debug.Log("Die()");
        stateManager.TransitionToState(StateType.Die);
    }

    public void DestroyOrRespawn()
    {
        if(respawnManager == null)
            DestroyObject();
        else
        {
            Initialize();
            respawnManager.Respawn();
        }
    }

    public void DestroyObject()
    {
        agentInput.OnMovement -= HandleMovement;
        agentInput.OnMovement -= spriteFlipper.FaceDirection;
        agentInput.OnWeaponChange -= weaponManager.HandleWeaponChange;

        Destroy(transform.parent.gameObject);
    }

    public void Initialize()
    {
        stateManager.TransitionToState(StateType.Idle);
        damageManager.Initialize(this, agentData.maxHealth);
    }
}
