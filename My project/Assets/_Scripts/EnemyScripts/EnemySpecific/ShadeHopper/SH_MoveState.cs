using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ShadeHopper MoveState class that inherits from the MoveState super class.
/// </summary>
public class SH_MoveState : EnemyMoveState
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
    /// <returns>Returns an instance of the SH_MoveState.</returns>
    public SH_MoveState(Entity entity, EnemyStateMachine stateMachine, string animBoolName, D_MoveState stateData, ShadeHopper shadeHopper) : base(entity, stateMachine, animBoolName, stateData)
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

        // Check if the player is within aggression range
        if (isPlayerInMinAgroRange)
        {
            // Detect the player
            stateMachine.ChangeState(shadeHopper.playerDetectedState);
        }
        // Otherwise check if entity is facing a wall or if state has expired
        else if(isDetectingWall || isWalkTimeOver)
        {
            // Flip the entity and transition to idling state.
            shadeHopper.idleState.SetFlipAfterIdle(true);
            stateMachine.ChangeState(shadeHopper.idleState);
        }

        // if(isWalkTimeOver)
        // {
        //     shadeHopper.idleState.SetFlipAfterIdle(true);
        //     stateMachine.ChangeState(shadeHopper.idleState);
        // }
    }

    /// <summary>
    /// Inherited method that manages physics updates.
    /// </summary>
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
