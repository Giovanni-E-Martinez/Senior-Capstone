using System.IO;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class that defines the ShadeHopper sub class of the Entity super class.
/// </summary>
public class ShadeHopper : Entity
{
    /// Each defined instance of the different states that a ShadowHopper entity may have.
    public SH_IdleState idleState { get; private set; }
    public SH_MoveState moveState { get; private set; }
    public SH_PlayerDetectedState playerDetectedState { get; private set; }
    public SH_ChargeState chargeState { get; private set; }
    public SH_LookForPlayerState lookForPlayerState { get; private set; }
    public SH_MeleeAttackState meleeAttackState { get; private set; }

    /// Variables that can be set within the Unity Editor.
    [SerializeField]
    private D_IdleState idleStateData;
    [SerializeField]
    private D_MoveState moveStateData;
    [SerializeField]
    private D_PlayerDetected playerDetectedData;
    [SerializeField]
    private D_ChargeState chargeStateData;
    [SerializeField]
    private D_LookForPlayer lookForPlayerStateData;
    [SerializeField]
    private D_MeleeAttack meleeAttackStateData;

    [SerializeField]
    private Transform meleeAttackPosition;

    /// <summary>
    /// Method that performs actions on initialization of the entity.
    /// </summary>
    public override void Start()
    {
        base.Start();

        // Instantiating and defining each state
        moveState = new SH_MoveState(this, stateMachine, "move", moveStateData, this);
        idleState = new SH_IdleState(this, stateMachine, "idle", idleStateData, this);
        playerDetectedState = new SH_PlayerDetectedState(this, stateMachine, "playerDetected", playerDetectedData, this);
        chargeState = new SH_ChargeState(this, stateMachine, "charge", chargeStateData, this);
        lookForPlayerState = new SH_LookForPlayerState(this, stateMachine, "lookForPlayer", lookForPlayerStateData, this);
        meleeAttackState = new SH_MeleeAttackState(this, stateMachine, "meleeAttack", meleeAttackPosition, meleeAttackStateData, this);

        // Initializing state machine
        stateMachine.Initialize(moveState);
    }

    /// <summary>
    /// Method used to draw on screen tools that allow for visualization and testing.
    /// </summary>
    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();

        Gizmos.DrawWireSphere(meleeAttackPosition.position, meleeAttackStateData.attackRadius);
    }
}
