using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// MeleeAttackState super class used for sub classes to inherit default data, which inherits the AttackState super class.
/// </summary>
public class MeleeAttackState : AttackState
{
    protected D_MeleeAttack stateData;
    protected AttackDetails attackDetails;
    
    /// <summary>
    /// Parameterized constructor used to initialize instances of the class.
    /// </summary>
    /// <param name="entity">The attached enemy entity.</param>
    /// <param name="stateMachine">The attached state machine.</param>
    /// <param name="animBoolName">The name of the performed animation.</param>
    /// <param name="attackPosition">The position of the attackPosition component transform.</param>
    /// <param name="stateData">Outside data used by the state to perform actions.</param>
    /// <returns>Returns an instance of the MeleeAttackState class.</returns>
    public MeleeAttackState(Entity entity, EnemyStateMachine stateMachine, string animBoolName, Transform attackPosition, D_MeleeAttack stateData) : base(entity, stateMachine, animBoolName, attackPosition)
    {
        this.stateData = stateData;
    }

    /// <summary>
    /// Inherited method used to perform data checks.
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

        attackDetails.damageAmount = stateData.attackDamage;
        attackDetails.position = entity.aliveGO.transform.position;
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
    }

    /// <summary>
    /// Inherited method that manages physics updates.
    /// </summary>
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    /// <summary>
    /// Inherited method used to perform actions when attack is triggered.
    /// </summary>
    public override void TriggerAttack()
    {
        base.TriggerAttack();

        // Find all colliders within attack radius
        Collider2D[] detectedObjects = Physics2D.OverlapCircleAll(attackPosition.position, stateData.attackRadius, stateData.whatIsPlayer);

        // For each collider found, send the "Damage" message to each object
        foreach (Collider2D collider in detectedObjects)
        {
            collider.transform.SendMessage("Damage", attackDetails);
        }
    }

    /// <summary>
    /// Inherited class used to perform actions when attack has ended.
    /// </summary>
    public override void FinishAttack()
    {
        base.FinishAttack();
    }
}
