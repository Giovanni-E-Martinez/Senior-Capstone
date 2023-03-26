using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SH_MoveState : EnemyMoveState
{
    private ShadeHopper shadeHopper;

    public SH_MoveState(Entity entity, EnemyStateMachine stateMachine, string animBoolName, D_MoveState stateData, ShadeHopper shadeHopper) : base(entity, stateMachine, animBoolName, stateData)
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

        if(isDetectingWall)
        {
            shadeHopper.idleState.SetFlipAfterIdle(true);
            stateMachine.ChangeState(shadeHopper.idleState);
        }

        if(isWalkTimeOver)
        {
            shadeHopper.idleState.SetFlipAfterIdle(true);
            stateMachine.ChangeState(shadeHopper.idleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
