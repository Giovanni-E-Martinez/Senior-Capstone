using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Super class used to define the base player object states.
/// </summary>
public class PlayerState
{
    protected Core core;

    protected Player player;
    protected PlayerStateMachine stateMachine;
    protected PlayerData playerData;
    protected float startTime;
    private string animBoolName;

    /// <summary>
    /// Parameterized constructor used to initialize class.
    /// </summary>
    /// <param name="player">Attached instance of the player.</param>
    /// <param name="stateMachine">Attached state machine.</param>
    /// <param name="playerData">Outside data used to perform actions.</param>
    /// <param name="animBoolName">Name of the animation to be performed.</param>
    public PlayerState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName)
    {
        this.player = player;
        this.stateMachine = stateMachine;
        this.playerData = playerData;
        this.animBoolName = animBoolName;
        this.core = player.Core;
    }

    /// <summary>
    /// Method used to perform actions on entry.
    /// </summary>
    public virtual void Enter()
    {
        DoChecks();
        player.Anim.SetBool(animBoolName, true);
        startTime = Time.time;
    }

    /// <summary>
    /// Method used to perform actions on exit.
    /// </summary>
    public virtual void Exit()
    {
        player.Anim.SetBool(animBoolName, false);
    }

    /// <summary>
    /// Method used to update logic data.
    /// </summary>
    public virtual void LogicUpdate()
    {

    }

    /// <summary>
    /// Method used to update physics data.
    /// </summary>
    public virtual void PhysicsUpdate()
    {
        DoChecks();
    }

    /// <summary>
    /// Method used to perform environment checks.
    /// </summary>
    public virtual void DoChecks()
    {

    }
}
