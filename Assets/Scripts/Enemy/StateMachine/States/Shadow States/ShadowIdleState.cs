using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowIdleState : EnemyState
{
    private EnemyShadow enemy;

    public ShadowIdleState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string animationBool, EnemyShadow _enemy) : base(_enemyBase, _stateMachine, animationBool)
    {
        enemy = _enemy;
    }

    public override void Enter()
    {
        base.Enter();
        enemy.SetZeroVelocity();
        stateTimer = enemy.idleTime;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (stateTimer < 0f)
            stateMachine.ChangeState(enemy.patrolState);
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }
}
