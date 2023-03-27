using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// EnemyIdleState super class used for sub classes to inherit default data, which inherits the EnemyState super class.
/// </summary>
public class EnemyIdleState : EnemyState
{
    protected D_IdleState stateData;
    protected bool flipAfterIdle;
    protected bool isIdleTimeOver;
    protected bool isPlayerInMinAgroRange;
    protected float idleTime;

    /// <summary>
    /// Parameterized constructor used to initialize instances of the class.
    /// </summary>
    /// <param name="entity">The attached enemy entity.</param>
    /// <param name="stateMachine">The attached state machine.</param>
    /// <param name="animBoolName">The name of the performed animation.</param>
    /// <param name="stateData">Outside data used by the state to perform actions.</param>
    /// <returns>Returns an instance of the EnemyIdleState class.</returns>
    public EnemyIdleState(Entity entity, EnemyStateMachine stateMachine, string animBoolName, D_IdleState stateData) : base(entity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    /// <summary>
    /// Inherited method used to perform data checks.
    /// </summary>
    public override void DoChecks()
    {
        base.DoChecks();
        
        isPlayerInMinAgroRange = entity.CheckPlayerInMinAgroRange();
    }

    /// <summary>
    /// Inherited method to perform initial functions when entering state.
    /// </summary>
    public override void Enter()
    {
        base.Enter();
        entity.SetVelocity(0f);
        isIdleTimeOver = false;
        SetRandomIdleTime();
    }

    /// <summary>
    /// Inherited method to perform final functions before exiting state.
    /// </summary>
    public override void Exit()
    {
        base.Exit();
        
        // Flip the entity if true
        if(flipAfterIdle)
        {
            entity.Flip();
        }
    }

    /// <summary>
    /// Inherited method that manages logic per frame.
    /// </summary>
    public override void LogicUpdate()
    {
        base.LogicUpdate();

        // Expire state once alloted time runs out
        if(Time.time >= startTime + idleTime)
        {
            isIdleTimeOver = true;
        }
    }

    /// <summary>
    /// Inherited method that manages physics updates.
    /// </summary>
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    /// <summary>
    /// Method used to define whether a flip should be performed after idling.
    /// </summary>
    /// <param name="flip">True of false.</param>
    public void SetFlipAfterIdle(bool flip)
    {
        flipAfterIdle = flip;
    }

    /// <summary>
    /// Method used to randomly select how long the entity will idle.
    /// </summary>
    private void SetRandomIdleTime()
    {
        idleTime = Random.Range(stateData.minIdleTime, stateData.maxIdleTime);
    }
}
