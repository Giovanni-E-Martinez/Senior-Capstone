using System.Security.Principal;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ShadeHopper PlayerDetectedState class that inherits from the PlayerDetectedState super class.
/// </summary>
public class SH_PlayerDetectedState : PlayerDetectedState
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
    /// <returns>Returns an instance of the SH_PlayerDetectedState.</returns>
    public SH_PlayerDetectedState(Entity entity, EnemyStateMachine stateMachine, string animBoolName, D_PlayerDetected stateData, ShadeHopper shadeHopper) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.shadeHopper = shadeHopper;
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

        // If performing close range action
        if(performCloseRangeAction)
        {
            // Transition to melee attacking state
            stateMachine.ChangeState(shadeHopper.meleeAttackState);
        }
        // If performing long range action
        else if (performLongRangeAction)
        {
            // Transition to charging state
            stateMachine.ChangeState(shadeHopper.chargeState);
        }
        // Otherwise if the player is not within aggression range
        else if(!isPlayerInMaxAgroRange)
        {
            // Transition to searching state
            stateMachine.ChangeState(shadeHopper.lookForPlayerState);
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
