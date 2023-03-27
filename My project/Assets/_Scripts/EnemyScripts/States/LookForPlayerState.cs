using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// LookForPlayerState super class used for sub classes to inherit default data, which inherits the EnemyState super class.
/// </summary>
public class LookForPlayerState : EnemyState
{
    protected D_LookForPlayer stateData;

    protected bool turnImmediately;
    protected bool isPlayerInMinAgroRange;
    protected bool isAllTurnsDone;
    protected bool isAllTurnsTimeDone;

    protected float lastTurnTime;

    protected int amountOfTurnsDone;

    /// <summary>
    /// Parameterized constructor used to initialize instances of the class.
    /// </summary>
    /// <param name="entity">The attached enemy entity.</param>
    /// <param name="stateMachine">The attached state machine.</param>
    /// <param name="animBoolName">The name of the performed animation.</param>
    /// <param name="stateData">Outside data used by the state to perform actions.</param>
    /// <returns>Returns an instance of the LookForPlayerState class.</returns>
    public LookForPlayerState(Entity entity, EnemyStateMachine stateMachine, string animBoolName, D_LookForPlayer stateData) : base(entity, stateMachine, animBoolName)
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
    }

    /// <summary>
    /// Inherited method to perform initial functions when entering state.
    /// </summary>
    public override void Enter()
    {
        base.Enter();

        isAllTurnsDone = false;
        isAllTurnsTimeDone = false;

        lastTurnTime = startTime;
        amountOfTurnsDone = 0;

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

        // Determine if entity shall turn immediately
        if(turnImmediately)
        {
            // Flip the entity
            entity.Flip();
            // Set last turn time
            lastTurnTime = Time.time;
            // Increase amount of turns performed
            amountOfTurnsDone++;
            // Set turnImmediately to false
            turnImmediately = false;
        }
        // If time has passed turn time and there are still turns to be performed
        else if(Time.time >= lastTurnTime + stateData.timeBetweenTurns && !isAllTurnsDone)
        {
            // Flip the entity
            entity.Flip();
            // Set last turn time
            lastTurnTime = Time.time;
            // Increase amount of turns performed
            amountOfTurnsDone++;
        }

        // If amount of turns is reached
        if(amountOfTurnsDone >= stateData.amountOfTurns)
        {
            // Set true
            isAllTurnsDone = true;
        }

        // If time has expired and all turns have been performed
        if(Time.time >= lastTurnTime + stateData.timeBetweenTurns && isAllTurnsDone)
        {
            // Set true
            isAllTurnsTimeDone = true;
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
    /// Method used to determine if the entity will turn upon entering state.
    /// </summary>
    /// <param name="flip">True or false.</param>
    public void SetTurnImmediately(bool flip)
    {
        turnImmediately = flip;
    }
}
