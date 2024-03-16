public class GoblinIdleState : EnemyState
{
    private EnemyGoblin enemy;

    public GoblinIdleState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string animationBool, EnemyGoblin _enemy) : base(_enemyBase, _stateMachine, animationBool)
    {
        enemy = _enemy;
    }

    public override void Enter()
    {
        base.Enter();

        enemy.SetZeroVelocity();
        stateTimer = enemy.idleTime;
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

    public override void Exit()
    {
        base.Exit();
    }
}
