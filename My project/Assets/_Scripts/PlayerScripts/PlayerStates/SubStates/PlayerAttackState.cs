using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerBaseState
{
    public PlayerAttackState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        core.Movement.SetVelocity(playerData.movementVelocity, input);

        if((input.x != 0 || input.y != 0) && (!player.InputHandler.AttackInputs[(int)CombatInputs.primary] && !player.InputHandler.AttackInputs[(int)CombatInputs.secondary]))
        {
            stateMachine.ChangeState(player.MoveState);
        }
        else if ((input.x == 0 && input.y == 0) && (!player.InputHandler.AttackInputs[(int)CombatInputs.primary] && !player.InputHandler.AttackInputs[(int)CombatInputs.secondary]))
        {
            stateMachine.ChangeState(player.IdleState);
        }

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}