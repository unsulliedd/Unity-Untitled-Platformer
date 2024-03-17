using UnityEngine;

public class GiantChaseState : EnemyState
{
    private EnemyGiant enemy;
    private Transform player;
    private int moveDirection;

    public GiantChaseState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string animationBool, EnemyGiant _enemy) : base(_enemyBase, _stateMachine, animationBool)
    {
        enemy = _enemy;
    }

    public override void Enter()
    {
        base.Enter();
        player = GameObject.FindWithTag("Player").transform;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (player.position.x > enemy.transform.position.x)
            moveDirection = 1;
        else
            moveDirection = -1;

        enemy.SetVelocity(enemy.moveSpeed * moveDirection, enemy.Rigidbody2D.velocity.y);

        //if (!enemy.CheckForPlayerInSight() || !isGrounded)
        //    stateMachine.ChangeState(enemy.patrolState);
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }
}
