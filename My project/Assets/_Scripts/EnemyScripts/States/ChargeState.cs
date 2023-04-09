using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ChargeState super class used for sub classes to inherit default data, which inherits the EnemyState super class.
/// </summary>
public class ChargeState : EnemyState
{
    protected D_ChargeState stateData;
    
    protected bool isPlayerInMinAgroRange;
    protected bool isPlayerInMaxAgroRange;
    protected bool isDetectingWall;
    protected bool isChargeTimeOver;
    protected bool performCloseRangeAction;
    
    /// <summary>
    /// Parameterized constructor used to initialize instances of the class.
    /// </summary>
    /// <param name="entity">The attached enemy entity.</param>
    /// <param name="stateMachine">The attached state machine.</param>
    /// <param name="animBoolName">The name of the performed animation.</param>
    /// <param name="stateData">Data used by the state to perform actions.</param>
    /// <returns>Returns an instance of the ChargeState class.</returns>
    public ChargeState(Entity entity, EnemyStateMachine stateMachine, string animBoolName, D_ChargeState stateData) : base(entity, stateMachine, animBoolName)
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
        isDetectingWall = entity.CheckWall();

        performCloseRangeAction = entity.CheckPlayerInCloseRangeAction();
    }

    /// <summary>
    /// Inherited method to perform initial functions when entering state.
    /// </summary>
    public override void Enter()
    {
        base.Enter();

        isChargeTimeOver = false;
        entity.FindPlayer(stateData.chargeSpeed);
        //TODO: test out using setvelocity over navmesh
        // entity.SetVelocity(stateData.chargeSpeed);
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
        
        // Expire state after set time has passed
        if(Time.time >= startTime + stateData.chargeTime)
        {
            isChargeTimeOver = true;
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