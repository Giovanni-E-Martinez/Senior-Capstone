using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ShadeHopper ChargeState class that inherits from ChargeState super class.
/// </summary>
public class SH_ChargeState : ChargeState
{
    /// <summary>
    /// Instance of the enemy entity.
    /// </summary>
    private ShadeHopper shadeHopper;

    /// <summary>
    /// Parameterized constructor used to initialize state.
    /// </summary>
    /// <param name="entity">The entity the state is attached to.</param>
    /// <param name="stateMachine">The state machine that is attached to the entity and manages state transitions.</param>
    /// <param name="animBoolName">Name of the animation called for the state.</param>
    /// <param name="stateData">Outside data attached to state to be used.</param>
    /// <param name="shadeHopper">Attached entity type.</param>
    /// <returns>Returns an instance of the SH_ChargeState.</returns>
    public SH_ChargeState(Entity entity, EnemyStateMachine stateMachine, string animBoolName, D_ChargeState stateData, ShadeHopper shadeHopper) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.shadeHopper = shadeHopper;
    }

    /// <summary>
    /// Inherited method to check environment data.
    /// </summary>
    public override void DoChecks()
    {
        base.DoChecks();
    }

    /// <summary>
    /// Inherited method to perform initial functions when entering state.
    /// </summary>
    public override void Enter()
    {
        base.Enter();
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

        // Locate player position
        entity.FindPlayer(stateData.chargeSpeed);
        // If within range, perform an attack
        if (performCloseRangeAction)
        {
            stateMachine.ChangeState(shadeHopper.meleeAttackState);
        }
        // If facing a wall, search for player
        else if (isDetectingWall)
        {
            stateMachine.ChangeState(shadeHopper.lookForPlayerState);
        }
        // If charge time runs out, determine next action
        else if (isChargeTimeOver)
        {
            // Detect player if player is within aggression range
            if (isPlayerInMinAgroRange)
            {
                stateMachine.ChangeState(shadeHopper.playerDetectedState);
            }
            // Search for player if player is outside of aggression range
            else if (!isPlayerInMaxAgroRange)
            {
                stateMachine.ChangeState(shadeHopper.lookForPlayerState);
            }
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
