public class GiantIdleState : EnemyState
{
    private EnemyGiant enemy;

    public GiantIdleState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string animBoolName, EnemyGiant _enemy) : base(_enemyBase, _stateMachine, animBoolName)
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
