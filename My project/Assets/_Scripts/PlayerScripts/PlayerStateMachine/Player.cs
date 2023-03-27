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
        // public PlayerDashState DashState { get; private set; }
        #endregion

        #region Object Components
        public Animator Anim { get; private set; }
        public PlayerInputHandler InputHandler { get; private set; }
        public Rigidbody2D RB { get; private set; }
        #endregion

        #region Public Variables
        public Vector2 CurrentVelocity { get; private set; }
        public int FacingDirection { get; private set; }
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
        StateMachine = new PlayerStateMachine();
        IdleState = new PlayerIdleState(this, StateMachine, playerData, "Idle");
        MoveState = new PlayerMoveState(this, StateMachine, playerData, "Move");
        // DashState = new PlayerDashState(this, StateMachine, playerData, "Dash");
    }

    /// <summary>
    /// Method used to initialize Player object components of scene start.
    /// </summary>
    private void Start()
    {
        Anim = GetComponent<Animator>();
        InputHandler = GetComponent<PlayerInputHandler>();
        RB = GetComponent<Rigidbody2D>();
        FacingDirection = 1;
        StateMachine.Initialize(IdleState);
    }

    /// <summary>
    /// Method used to update per frame.
    /// </summary>
    private void Update()
    {
        CurrentVelocity = RB.velocity;
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

    #region Set Methods
    /// <summary>
    /// Method used to set the velocity of the player object.
    /// </summary>
    /// <param name="velocityX">X axis velocity.</param>
    /// <param name="velocityY">Y axis velocity.</param>
    public void SetVelocity(float velocityX, float velocityY)
    {
        workSpace.Set(velocityX, velocityY);
        RB.velocity = workSpace;
        CurrentVelocity = workSpace;
    }
    #endregion

    #region Check Methods
    /// <summary>
    /// Method used to determine if player should flip.
    /// </summary>
    /// <param name="xInput">X axis input.</param>
    public void CheckIfShouldFlip(int xInput)
    {
        if(xInput != 0 && xInput != FacingDirection)
        {
            Flip();
        }
    }
    #endregion

    #region Other Methods
    /// <summary>
    /// Method used to fip the player object.
    /// </summary>
    private void Flip()
    {
        FacingDirection *= -1;
        // transform.Rotate(0.0f, 180.0f, 0.0f);
        gameObject.GetComponent<SpriteRenderer>().flipX = !gameObject.GetComponent<SpriteRenderer>().flipX;
    }
    #endregion
}
