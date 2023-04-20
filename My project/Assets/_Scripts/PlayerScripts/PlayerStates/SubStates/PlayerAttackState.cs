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

        Movement.CheckIfShouldFlip((int)moveInput.x);
        Movement.SetVelocity(playerData.movementVelocity, moveInput);
        weapon.pointerAngle = GetPointerInput();
        weapon.attackInput = true;

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
            weapon.attackInput = false;
            stateMachine.ChangeState(player.MoveState);
        }
        else if ((moveInput.x == 0 && moveInput.y == 0) && (!player.InputHandler.AttackInputs[(int)CombatInputs.primary] && !player.InputHandler.AttackInputs[(int)CombatInputs.secondary]))
        {
            weapon.attackInput = false;
            stateMachine.ChangeState(player.IdleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    private float GetPointerInput()
    {
        Vector3 pointerPos = lookInput;
        pointerPos.z = Camera.main.nearClipPlane;
        float degrees = 0f;
        Vector2 distance = new Vector2();

        if(!isController)
        {
            pointerPos = Camera.main.ScreenToWorldPoint(pointerPos);
            distance = (pointerPos - weapon.transform.position).normalized;
            degrees = Mathf.Atan2(distance.y, distance.x) * Mathf.Rad2Deg;
        }
        else
        {
            degrees = Mathf.Atan2(pointerPos.y, pointerPos.x) * Mathf.Rad2Deg;
        }

        return degrees;
    }
}