using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class used to create and initialize the state machine for enemies.
/// </summary>
public class EnemyStateMachine
{
    // Instance of the initial state.
    public EnemyState CurrentState { get; private set; }

    /// <summary>
    /// Method used to initialize the starting state of the state machine.
    /// </summary>
    /// <param name="startingState">The initial state an entity will enter with.</param>
    public void Initialize(EnemyState startingState)
    {
        CurrentState = startingState;
        CurrentState.Enter();
    }

    /// <summary>
    /// Method used to transition between different states.
    /// </summary>
    /// <param name="newState">The state that will be transition to.</param>
    public void ChangeState(EnemyState newState)
    {
        CurrentState.Exit();
        CurrentState = newState;
        CurrentState.Enter();
    }
}
