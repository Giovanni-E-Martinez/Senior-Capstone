using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// PlayerBaseState sub class of the PlayerState super class.
/// </summary>
public class PlayerBaseState : PlayerState
{
    protected Vector2 input;
    protected Movement Movement
    {
        get => movement ?? core.GetCoreComponent(ref movement);
    }
    private Movement movement;
    // protected bool dashInput;

    /// <summary>
    /// Parameterized constructor used to initialize the instance of the class.
    /// </summary>
    /// <param name="player">Attached instance of the player.</param>
    /// <param name="stateMachine">Attached instance of the state machine.</param>
    /// <param name="playerData">Outside data used to perform actions.</param>
    /// <param name="animBoolName">Name of the performed animation.</param>
    /// <returns>Returns an instance of the PlayerBaseState class.</returns>
    public PlayerBaseState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
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

        input = new Vector2(player.InputHandler.NormInputX, player.InputHandler.NormInputY);

        if(player.InputHandler.AttackInputs[(int)CombatInputs.primary])
        {
            stateMachine.ChangeState(player.PrimaryAttackState);
        }
        else if(player.InputHandler.AttackInputs[(int)CombatInputs.secondary])
        {
            stateMachine.ChangeState(player.SecondaryAttackState);
        }

        // dashInput = player.InputHandler.DashInput;

        // if(dashInput && player.DashState.CheckIfCanDash())
        // {
        //     stateMachine.ChangeState(player.DashState);
        // }
    }

    /// <summary>
    /// Inherited method used to perform physics updates.
    /// </summary>
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
