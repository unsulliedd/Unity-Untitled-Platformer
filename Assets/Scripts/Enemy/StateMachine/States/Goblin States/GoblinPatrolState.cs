using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinPatrolState : EnemyState
{
    private EnemyGoblin enemy;

    public GoblinPatrolState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string animationBool, EnemyGoblin _enemy) : base(_enemyBase, _stateMachine, animationBool)
    {
        enemy = _enemy;
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

        enemy.SetVelocity(enemy.moveSpeed * enemy.facingDirection, enemy.Rigidbody2D.velocity.y);
        if (!isGrounded || isTouchingWall)
        {
            enemy.Flip();
            stateMachine.ChangeState(enemy.idleState);
        }

        if (enemy.CheckForPlayerInSight())
            stateMachine.ChangeState(enemy.chaseState);
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }
}
