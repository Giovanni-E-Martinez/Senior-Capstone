using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class used to define and initialize the player state machine.
/// </summary>
public class PlayerStateMachine
{
    public PlayerState CurrentState { get; private set; }

    /// <summary>
    /// Method used to define state on initialization.
    /// </summary>
    /// <param name="startingState">Initial state of the player.</param>
    public void Initialize(PlayerState startingState)
    {
        CurrentState = startingState;
        CurrentState.Enter();
    }

    /// <summary>
    /// Method used to define state on transition.
    /// </summary>
    /// <param name="newState">State to be transitioned to.</param>
    public void ChangeState(PlayerState newState)
    {
        CurrentState.Exit();
        CurrentState = newState;
        CurrentState.Enter();
    }
}
