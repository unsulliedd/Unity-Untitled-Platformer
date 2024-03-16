public class GiantChaseState : EnemyState
{
    private EnemyGiant enemy;

    public GiantChaseState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string animationBool, EnemyGiant _enemy) : base(_enemyBase, _stateMachine, animationBool)
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
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }
}
