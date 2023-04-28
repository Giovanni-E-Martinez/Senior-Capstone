using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Sub state of the PlayerState super state used to define the methods for player ability based actions.
/// </summary>
public class PlayerAbilityState : PlayerState
{
    protected bool isAbilityDone;
    protected bool isController;
    protected Vector2 moveInput;
    protected Vector2 lookInput;
    protected Movement Movement
    {
        get => movement ?? core.GetCoreComponent(ref movement);
    }
    private Movement movement;

    /// <summary>
    /// Parameterized constructor used to define and initialize the PlayerAbilityState state.
    /// </summary>
    /// <param name="player">Defined player entity.</param>
    /// <param name="stateMachine">Defined state machine assigned to the player entity.</param>
    /// <param name="playerData">Assiged player state data.</param>
    /// <param name="animBoolName">Current active animation</param>
    /// <returns></returns>
    public PlayerAbilityState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    /// <summary>
    /// Performs environment checks.
    /// </summary>
    public override void DoChecks()
    {
        base.DoChecks();
    }

    /// <summary>
    /// Called on initialization, sets base ability use identifier to false.
    /// </summary>
    public override void Enter()
    {
        base.Enter();

        isAbilityDone = false;
    }

    /// <summary>
    /// Called on deactivation to exit object.
    /// </summary>
    public override void Exit()
    {
        base.Exit();
    }

    /// <summary>
    /// Called at the beginning of each frame to perform logic processes.
    /// </summary>
    public override void LogicUpdate()
    {
        base.LogicUpdate();

        isController = player.InputHandler.ControlScheme();
        moveInput = new Vector2(player.InputHandler.NormInputX, player.InputHandler.NormInputY);
        lookInput = player.InputHandler.RawLookInput;
    }

    /// <summary>
    /// Called on fixed intervals to perform physics processes.
    /// </summary>
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
