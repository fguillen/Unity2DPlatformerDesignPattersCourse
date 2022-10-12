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
    [HideInInspector] public PlayerInAreaSensor playerInAreaSensor;
    [HideInInspector] public EndOfGroundSensor endOfGroundSensor;
    [HideInInspector] public WeaponManager weaponManager;
    [HideInInspector] public StateManager stateManager;
    [HideInInspector] public DamageManager damageManager;
    [HideInInspector] public RespawnManager respawnManager;
    [HideInInspector] public PointsManager pointsManager;

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
        playerInAreaSensor = GetComponentInChildren<PlayerInAreaSensor>();
        endOfGroundSensor = GetComponentInChildren<EndOfGroundSensor>();

        weaponManager = GetComponentInChildren<WeaponManager>();
        stateManager = GetComponentInChildren<StateManager>();
        damageManager = GetComponentInChildren<DamageManager>();
        pointsManager = GetComponentInChildren<PointsManager>();
        respawnManager = GetComponentInChildren<RespawnManager>();
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
        respawnManager?.Initialize(this);
        pointsManager?.Initialize();
        damageManager.Initialize(this, agentData.maxHealth);
        stateManager.Initialize(this);
        weaponManager.Initialize(this);

        stateManager.TransitionToState(StateType.Idle);
    }
}
