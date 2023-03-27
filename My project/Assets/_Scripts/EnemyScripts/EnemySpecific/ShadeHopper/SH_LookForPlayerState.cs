using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ShadeHopper LookForPlayerState class that inherits from LookForPlayerState super class.
/// </summary>
public class SH_LookForPlayerState : LookForPlayerState
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
    /// <returns>Returns an instance of the SH_LookForPlayerState.</returns>
    public SH_LookForPlayerState(Entity entity, EnemyStateMachine stateMachine, string animBoolName, D_LookForPlayer stateData, ShadeHopper shadeHopper) : base(entity, stateMachine, animBoolName, stateData)
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

        // Check if player is within aggression range
        if(isPlayerInMinAgroRange)
        {
            // Detect player
            stateMachine.ChangeState(shadeHopper.playerDetectedState);
        }
        // Otherwise if the amount of alloted turns are reached
        else if(isAllTurnsTimeDone)
        {
            // Transition to movement state
            stateMachine.ChangeState(shadeHopper.moveState);
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
