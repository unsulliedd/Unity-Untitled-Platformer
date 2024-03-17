public class GiantPatrolState : EnemyState
{
    private EnemyGiant enemy;

    public GiantPatrolState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string animationBool, EnemyGiant _enemy) : base(_enemyBase, _stateMachine, animationBool)
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

        if (!isGrounded || isTouchingWall)
        {
            enemy.Flip();
            stateMachine.ChangeState(enemy.idleState);
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();

        enemy.SetVelocity(enemy.moveSpeed * enemy.facingDirection, enemy.Rigidbody2D.velocity.y);
    }
}
