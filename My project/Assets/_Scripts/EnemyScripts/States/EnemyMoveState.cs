using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// EnemyMoveState super class used for sub classes to inherit default data, which inherits the EnemyState super class.
/// </summary>
public class EnemyMoveState : EnemyState
{
    protected D_MoveState stateData;
    protected bool isDetectingWall;
    protected bool isWalkTimeOver;
    protected bool isPlayerInMinAgroRange;
    protected float walkTime;

    /// <summary>
    /// Parameterized constructor used to initialize instances of the class.
    /// </summary>
    /// <param name="entity">The attached enemy entity.</param>
    /// <param name="stateMachine">The attached state machine.</param>
    /// <param name="animBoolName">The name of the performed animation.</param>
    /// <param name="stateData">Outside data used by the state to perform actions.</param>
    /// <returns>Returns an instance of the EnemyMoveState class.</returns>
    public EnemyMoveState(Entity entity, EnemyStateMachine stateMachine, string animBoolName, D_MoveState stateData) : base(entity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }
    
    /// <summary>
    /// Inherited method used to perform data checks.
    /// </summary>
    public override void DoChecks()
    {
        base.DoChecks();

        isDetectingWall = entity.CheckWall();
        isPlayerInMinAgroRange = entity.CheckPlayerInMinAgroRange();
    }

    /// <summary>
    /// Inherited method to perform initial functions when entering state.
    /// </summary>
    public override void Enter()
    {
        base.Enter();

        entity.SetVelocity(stateData.movementSpeed);
        isWalkTimeOver = false;
        SetRandomWalkTime();
    }

    /// <summary>
    /// Inherited method to perform final functions before exiting state.
    /// </summary>
    public override void Exit()
    {
        base.Exit();
    }

    /// <summary>
    /// Inherited method that manages logic per frame.
    /// </summary>
    public override void LogicUpdate()
    {
        base.LogicUpdate();

        // Expire state if the time exceeds the alloted walk time.
        if(Time.time >= startTime + walkTime)
        {
            isWalkTimeOver = true;
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
    /// Method used to set the random amount of time that an entity will walk.
    /// </summary>
    private void SetRandomWalkTime()
    {
        walkTime = Random.Range(stateData.minWalkTime, stateData.maxWalkTime);
    }
}
