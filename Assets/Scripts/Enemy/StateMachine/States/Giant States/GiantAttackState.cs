public class GiantAttackState : EnemyState
{
    private EnemyGiant enemy;

    public GiantAttackState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string animationBool, EnemyGiant _enemy) : base(_enemyBase, _stateMachine, animationBool)
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

        enemy.AttackHit();

        if (!enemy.PlayerInRange())
            stateMachine.ChangeState(enemy.patrolState);
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }
}
