using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerAbilityState
{
    private Weapon weapon;

    public PlayerAttackState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName, Weapon weapon) : base(player, stateMachine, playerData, animBoolName)
    {
        this.weapon = weapon;

        // weapon.OnExit += ExitHandler;
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();

        weapon.Enter();
    }

    public override void Exit()
    {
        base.Exit();
        
        weapon.Exit();
        player.Anim.SetBool("MoveAttack", false);
        player.Anim.SetBool("IdleAttack", false);

        // weapon.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        core.Movement.CheckIfShouldFlip((int)moveInput.x);
        core.Movement.SetVelocity(playerData.movementVelocity, moveInput);
        weapon.PointerPosition = GetPointerInput();

        if((moveInput.x != 0 || moveInput.y != 0) && (player.InputHandler.AttackInputs[(int)CombatInputs.primary] || player.InputHandler.AttackInputs[(int)CombatInputs.secondary]))
        {
            player.Anim.SetBool("IdleAttack", false);
            player.Anim.SetBool("MoveAttack", true);
        }
        else if ((moveInput.x == 0 && moveInput.y == 0) && (player.InputHandler.AttackInputs[(int)CombatInputs.primary] || player.InputHandler.AttackInputs[(int)CombatInputs.secondary]))
        {
            player.Anim.SetBool("MoveAttack", false);
            player.Anim.SetBool("IdleAttack", true);
        }
        else if((moveInput.x != 0 || moveInput.y != 0) && (!player.InputHandler.AttackInputs[(int)CombatInputs.primary] && !player.InputHandler.AttackInputs[(int)CombatInputs.secondary]))
        {
            stateMachine.ChangeState(player.MoveState);
        }
        else if ((moveInput.x == 0 && moveInput.y == 0) && (!player.InputHandler.AttackInputs[(int)CombatInputs.primary] && !player.InputHandler.AttackInputs[(int)CombatInputs.secondary]))
        {
            stateMachine.ChangeState(player.IdleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    private Vector2 GetPointerInput()
    {
        Vector3 pointerPos = lookInput;
        pointerPos.z = Camera.main.nearClipPlane;
        return Camera.main.ScreenToWorldPoint(pointerPos);
    }
}