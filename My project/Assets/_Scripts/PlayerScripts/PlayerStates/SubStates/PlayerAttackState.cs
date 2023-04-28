using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Substate of the PlayerAbilityState super state that allows the game to process attack inputs.
/// </summary>
public class PlayerAttackState : PlayerAbilityState
{
    private Weapon weapon;

    /// <summary>
    /// Parameterized constructor for the state.
    /// </summary>
    /// <param name="player">The retrieved player object.</param>
    /// <param name="stateMachine">The retrived state machine in use.</param>
    /// <param name="playerData">The retrieved player state data.</param>
    /// <param name="animBoolName">The currently defined active animation.</param>
    /// <param name="weapon">The current weapon in use.</param>
    /// <returns></returns>
    public PlayerAttackState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName, Weapon weapon) : base(player, stateMachine, playerData, animBoolName)
    {
        this.weapon = weapon;

        // weapon.OnExit += ExitHandler;
    }

    /// <summary>
    /// Inherited method to run environment checks.
    /// </summary>
    public override void DoChecks()
    {
        base.DoChecks();
    }

    /// <summary>
    /// Method used to initialize the weapon and run inherited processes.
    /// </summary>
    public override void Enter()
    {
        base.Enter();

        weapon.Enter();
    }

    /// <summary>
    /// Method used to deactivate the weapon and return to a previous state.
    /// </summary>
    public override void Exit()
    {
        base.Exit();
        
        weapon.Exit();
        player.Anim.SetBool("MoveAttack", false);
        player.Anim.SetBool("IdleAttack", false);

        // weapon.Exit();
    }

    /// <summary>
    /// Called at the beginning of each from to perform game/player logic execution.
    /// </summary>
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

    /// <summary>
    /// Inherited method called on fixed intervals.
    /// </summary>
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    /// <summary>
    /// Method used to retrieve and return mouse cursor location data.
    /// </summary>
    /// <returns>Returns current location relative to the player object in the form of an angle.</returns>
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