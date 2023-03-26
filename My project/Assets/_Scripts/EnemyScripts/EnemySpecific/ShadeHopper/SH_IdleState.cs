using System.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SH_IdleState : EnemyIdleState
{
    private ShadeHopper shadeHopper;

    public SH_IdleState(Entity entity, EnemyStateMachine stateMachine, string animBoolName, D_IdleState stateData, ShadeHopper shadeHopper) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.shadeHopper = shadeHopper;
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

        if(isIdleTimeOver)
        {
            stateMachine.ChangeState(shadeHopper.moveState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
