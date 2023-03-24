using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Properties and Variables
        #region State Variables
        public PlayerStateMachine StateMachine { get; private set; }
        public PlayerIdleState IdleState { get; private set; }
        public PlayerMoveState MoveState { get; set; }
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
    private void Awake()
    {
        StateMachine = new PlayerStateMachine();
        IdleState = new PlayerIdleState(this, StateMachine, playerData, "Idle");
        MoveState = new PlayerMoveState(this, StateMachine, playerData, "Move");
    }

    private void Start()
    {
        Anim = GetComponent<Animator>();
        InputHandler = GetComponent<PlayerInputHandler>();
        RB = GetComponent<Rigidbody2D>();
        FacingDirection = 1;
        StateMachine.Initialize(IdleState);
    }

    private void Update()
    {
        CurrentVelocity = RB.velocity;
        StateMachine.CurrentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }
    #endregion

    #region Set Methods
    public void SetVelocity(float velocityX, float velocityY)
    {
        workSpace.Set(velocityX, velocityY);
        RB.velocity = workSpace;
        CurrentVelocity = workSpace;
    }
    #endregion

    #region Check Methods
    public void CheckIfShouldFlip(int xInput)
    {
        Debug.Log(xInput);
        if(xInput != 0 && xInput != FacingDirection)
        {
            Flip();
        }
    }
    #endregion

    #region Other Methods
    private void Flip()
    {
        Debug.Log("Flipping");
        FacingDirection *= -1;
        transform.Rotate(0.0f, 180.0f, 0.0f);
        gameObject.GetComponent<SpriteRenderer>().flipX = !gameObject.GetComponent<SpriteRenderer>().flipX;
    }
    #endregion
}
