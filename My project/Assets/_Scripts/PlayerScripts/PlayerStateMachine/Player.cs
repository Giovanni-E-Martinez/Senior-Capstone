using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class used to initialize and create the player object.
/// </summary>
public class Player : MonoBehaviour
{
    #region Properties and Variables
        #region State Properties
        public PlayerStateMachine StateMachine { get; private set; }
        public PlayerIdleState IdleState { get; private set; }
        public PlayerMoveState MoveState { get; private set; }
        public PlayerAttackState PrimaryAttackState { get; private set; }
        public PlayerAttackState SecondaryAttackState { get; private set; }
        // public PlayerDashState DashState { get; private set; }
        #endregion

        #region Object Components
        public Animator Anim { get; private set; }
        public PlayerInputHandler InputHandler { get; private set; }
        public Core Core { get; private set; }
        #endregion

        #region Public Variables
        public HealthBar healthBar;
        #endregion

        #region Scriptable Objects
        [SerializeField]
        private PlayerData playerData;
        #endregion

        #region Local Variables
        private Vector2 workSpace;
        private Weapon primaryWeapon;
        private Weapon secondaryWeapon;
        #endregion
    #endregion

    #region Unity Callback Methods
    /// <summary>
    /// Method used to initialize Player object on scene activation.
    /// </summary>
    private void Awake()
    {
        Core = GetComponentInChildren<Core>();
        primaryWeapon = transform.Find("PrimaryWeapon").GetComponent<Weapon>();
        secondaryWeapon = transform.Find("SecondaryWeapon").GetComponent<Weapon>();
        StateMachine = new PlayerStateMachine();
        IdleState = new PlayerIdleState(this, StateMachine, playerData, "Idle");
        MoveState = new PlayerMoveState(this, StateMachine, playerData, "Move");
        PrimaryAttackState = new PlayerAttackState(this, StateMachine, playerData, "Attack", primaryWeapon);
        SecondaryAttackState = new PlayerAttackState(this, StateMachine, playerData, "Attack", secondaryWeapon);
        healthBar.SetMaxHealth(Core.GetCoreComponent<Stats>().Health.MaxValue);
        // DashState = new PlayerDashState(this, StateMachine, playerData, "Dash");
    }

    /// <summary>
    /// Method used to initialize Player object components of scene start.
    /// </summary>
    private void Start()
    {
        Anim = GetComponent<Animator>();
        InputHandler = GetComponent<PlayerInputHandler>();
        StateMachine.Initialize(IdleState);
    }

    /// <summary>
    /// Method used to update per frame.
    /// </summary>
    private void Update()
    {
        Core.LogicUpdate();
        StateMachine.CurrentState.LogicUpdate();
    }

    /// <summary>
    /// Method used to update on fixed intervals.
    /// </summary>
    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
        healthBar.SetHealth(Core.GetCoreComponent<Stats>().Health.CurrentValue);
    }
    #endregion
}
