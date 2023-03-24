using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerBaseState : PlayerState
{
    protected Vector2 input;

    public PlayerBaseState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
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

        input = new Vector2(player.InputHandler.NormInputX, player.InputHandler.NormInputY);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
