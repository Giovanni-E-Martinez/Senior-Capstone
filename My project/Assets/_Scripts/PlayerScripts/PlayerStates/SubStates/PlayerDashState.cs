// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class PlayerDashState : PlayerBaseState
// {
//     public bool CanDash { get; private set; }
//     private bool isHolding;
//     private float lastDashTime;
//     private Vector2 dashDirection;

//     public PlayerDashState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
//     {

//     }

//     public override void Enter()
//     {
//         base.Enter();

//         Debug.Log("Dashing");
//         CanDash = false;
//         player.InputHandler.UseDashInput();
//         dashDirection = new Vector2(player.InputHandler.NormInputX, player.InputHandler.NormInputY);
//     }

//     public override void Exit()
//     {
//         base.Exit();
//     }

//     public override void LogicUpdate()
//     {
//         base.LogicUpdate();

//         player.SetVelocity(playerData.dashVelocity * dashDirection.x, playerData.dashVelocity * dashDirection.y);
//     }

//     public bool CheckIfCanDash()
//     {
//         return CanDash && Time.time >= lastDashTime + playerData.dashCooldown;
//     }

//     public void ResetCanDash() => CanDash = true;

// }
