using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadeHopper : Entity
{
    public SH_IdleState idleState { get; private set; }
    public SH_MoveState moveState { get; private set; }

    [SerializeField]
    private D_IdleState idleStateData;
    [SerializeField]
    private D_MoveState moveStateData;

    public override void Start()
    {
        base.Start();

        moveState = new SH_MoveState(this, stateMachine, "move", moveStateData, this);
        idleState = new SH_IdleState(this, stateMachine, "idle", idleStateData, this);

        stateMachine.Initialize(moveState);
    }
}
