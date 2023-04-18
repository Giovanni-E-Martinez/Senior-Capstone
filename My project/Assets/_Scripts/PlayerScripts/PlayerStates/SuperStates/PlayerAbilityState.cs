using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        isController = player.InputHandler.ControlScheme();
        moveInput = new Vector2(player.InputHandler.NormInputX, player.InputHandler.NormInputY);
        lookInput = player.InputHandler.RawLookInput;
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
