using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilityState : PlayerState
{
    protected bool isAbilityDone;
    protected Vector2 moveInput;
    protected Vector2 lookInput;

    public PlayerAbilityState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();

        isAbilityDone = false;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        moveInput = new Vector2(player.InputHandler.NormInputX, player.InputHandler.NormInputY);
        lookInput = player.InputHandler.NormLookInput;
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
