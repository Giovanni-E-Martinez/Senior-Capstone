using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// PlayerDetectedState super class used for sub classes to inherit default data, which inherits the EnemyState super class.
/// </summary>
public class PlayerDetectedState : EnemyState
{
    protected D_PlayerDetected stateData;

    protected bool isPlayerInMinAgroRange;
    protected bool isPlayerInMaxAgroRange;
    protected bool performLongRangeAction;
    protected bool performCloseRangeAction;

    /// <summary>
    /// Parameterized constructor used to initialize instances of the class.
    /// </summary>
    /// <param name="entity">The attached enemy entity.</param>
    /// <param name="stateMachine">The attached state machine.</param>
    /// <param name="animBoolName">The name of the performed animation.</param>
    /// <param name="stateData">Outside data used by the state to perform actions.</param>
    /// <returns>Returns an instance of the PlayerDetectedState class.</returns>
    public PlayerDetectedState(Entity entity, EnemyStateMachine stateMachine, string animBoolName, D_PlayerDetected stateData) : base(entity, stateMachine, animBoolName)
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
        isPlayerInMaxAgroRange = entity.CheckPlayerInMaxAgroRange();
        
        performCloseRangeAction = entity.CheckPlayerInCloseRangeAction();
    }

    /// <summary>
    /// Inherited method to perform initial functions when entering state.
    /// </summary>
    public override void Enter()
    {
        base.Enter();

        performLongRangeAction = false;
        entity.SetVelocity(0f);
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

        // If time expires perform long range action
        if(Time.time >= startTime + stateData.longRangeActionTime)
        {
            performLongRangeAction = true;
        }
    }

    /// <summary>
    /// Inherited method that manages physics updates.
    /// </summary>
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}