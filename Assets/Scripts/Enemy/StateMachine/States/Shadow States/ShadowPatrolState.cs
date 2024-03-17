public class ShadowPatrolState : EnemyState
{
    private EnemyShadow enemy;

    public ShadowPatrolState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string animationBool, EnemyShadow _enemy) : base(_enemyBase, _stateMachine, animationBool)
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

        if (enemy.PlayerInRange())
        {
            if (enemy.CanAttack())
            {
                stateMachine.ChangeState(enemy.attackState);
            }
            else
            {
                enemy.MoveTowardsPlayer();
            }
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }
}
