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
        // Currently empty.
        #endregion

        #region Scriptable Objects
        [SerializeField]
        private PlayerData playerData;
        #endregion

        #region Local Variables
        private Vector2 workSpace;
        #endregion
    #endregion

    #region Unity Callback Methods
    /// <summary>
    /// Method used to initialize Player object on scene activation.
    /// </summary>
    private void Awake()
    {
        Core = GetComponentInChildren<Core>();
        StateMachine = new PlayerStateMachine();
        IdleState = new PlayerIdleState(this, StateMachine, playerData, "Idle");
        MoveState = new PlayerMoveState(this, StateMachine, playerData, "Move");
        PrimaryAttackState = new PlayerAttackState(this, StateMachine, playerData, "Attack");
        SecondaryAttackState = new PlayerAttackState(this, StateMachine, playerData, "Attack");
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
    }
    #endregion
}
