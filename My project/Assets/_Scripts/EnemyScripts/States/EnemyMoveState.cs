using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveState : EnemyState
{
    protected D_MoveState stateData;
    protected bool isDetectingWall;
    protected bool isWalkTimeOver;
    protected float walkTime;

    public EnemyMoveState(Entity entity, EnemyStateMachine stateMachine, string animBoolName, D_MoveState stateData) : base(entity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();
        entity.SetVelocity(stateData.movementSpeed);
        isDetectingWall = entity.CheckWall();
        isWalkTimeOver = false;
        SetRandomWalkTime();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(Time.time >= startTime + walkTime)
        {
            isWalkTimeOver = true;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        
        isDetectingWall = entity.CheckWall();
    }

    private void SetRandomWalkTime()
    {
        walkTime = Random.Range(stateData.minWalkTime, stateData.maxWalkTime);
    }
}
