using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// EnemyState base super class.
/// </summary>
public class EnemyState
{
    // Instances of the state machine and the entity.
    protected EnemyStateMachine stateMachine;
    protected Entity entity;

    protected float startTime;

    protected string animBoolName;
    
    /// <summary>
    /// Parameterized constructor used to create an instance of the class.
    /// </summary>
    /// <param name="entity">The attached enemy.</param>
    /// <param name="stateMachine">The attached state machine.</param>
    /// <param name="animBoolName">The name of the animation performed.</param>
    public EnemyState(Entity entity, EnemyStateMachine stateMachine, string animBoolName)
    {
        this.entity = entity;
        this.stateMachine = stateMachine;
        this.animBoolName = animBoolName;
    }

    /// <summary>
    /// Method to perform initial functions when entering state.
    /// </summary>
    public virtual void Enter()
    {
        startTime = Time.time;
        entity.anim.SetBool(animBoolName, true);
        DoChecks();
    }

    /// <summary>
    /// Method to perform final functions before exiting state.
    /// </summary>
    public virtual void Exit()
    {
        entity.anim.SetBool(animBoolName, false);
    }

    /// <summary>
    /// Method that manages logic per frame.
    /// </summary>
    public virtual void LogicUpdate()
    {

    }

    /// <summary>
    /// Method that manages physics updates.
    /// </summary>
    public virtual void PhysicsUpdate()
    {
        DoChecks();
    }

    /// <summary>
    /// Method to check environment data.
    /// </summary>
    public virtual void DoChecks()
    {

    }
}
