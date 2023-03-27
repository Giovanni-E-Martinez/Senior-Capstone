using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ShadeHopper MeleeAttackState that inherits from the MeleeAttackState super class.
/// </summary>
public class SH_MeleeAttackState : MeleeAttackState
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
    /// <param name="attackPosition">Reference to child transform of the entity for attack origin.</param>
    /// <param name="stateData">Outside data attached to state to be used.</param>
    /// <param name="shadeHopper">Attached entity type.</param>
    /// <returns>Returns an instance of the SH_MeleeAttackState.</returns>
    public SH_MeleeAttackState(Entity entity, EnemyStateMachine stateMachine, string animBoolName, Transform attackPosition, D_MeleeAttack stateData, ShadeHopper shadeHopper) : base(entity, stateMachine, animBoolName, attackPosition, stateData)
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

        // When the animation reaches its end
        if(isAnimationFinished)
        {
            // If player is within aggression range
            if(isPlayerInMinAgroRange)
            {
                // Detect the player
                stateMachine.ChangeState(shadeHopper.playerDetectedState);
            }
            else
            {
                // Otherwise search for the player
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

    /// <summary>
    /// Inherited method that manages attack trigger actions.
    /// </summary>
    public override void TriggerAttack()
    {
        base.TriggerAttack();
    }

    /// <summary>
    /// Inherited method that manages attack end actions.
    /// </summary>
    public override void FinishAttack()
    {
        base.FinishAttack();
    }
}
