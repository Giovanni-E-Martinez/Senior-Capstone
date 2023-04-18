using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// PlayerIdleState sub class of the PlayerBaseState super class.
/// </summary>
public class PlayerIdleState : PlayerBaseState
{
    /// <summary>
    /// Parameterized constructor used to initialize the instance of the class.
    /// </summary>
    /// <param name="player">Attached instance of the player.</param>
    /// <param name="stateMachine">Attached instance of the state machine.</param>
    /// <param name="playerData">Outside data used to perform actions.</param>
    /// <param name="animBoolName">Name of the performed animation.</param>
    /// <returns>Returns an instance of the PlayerIdleState class.</returns>
    public PlayerIdleState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
        
    }

    /// <summary>
    /// Inherited method used to perform environment checks.
    /// </summary>
    public override void DoChecks()
    {
        base.DoChecks();
    }

    /// <summary>
    /// Inherited method used to perform actions on entry.
    /// </summary>
    public override void Enter()
    {
        base.Enter();
        Movement.SetVelocity(0, Vector2.zero);
    }

    /// <summary>
    /// Inherited method used to perform actions on exit.
    /// </summary>
    public override void Exit()
    {
        base.Exit();
    }

    /// <summary>
    /// Inherited method used to perform logic updates.
    /// </summary>
    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(input.x != 0 || input.y != 0)
        {
            stateMachine.ChangeState(player.MoveState);
        }
    }

    /// <summary>
    /// Inherited method used to perform physics updates.
    /// </summary>
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}