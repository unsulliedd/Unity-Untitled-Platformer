using UnityEngine;

public class EnemyState 
{
    #region References
    protected EnemyStateMachine stateMachine;
    protected Enemy enemyBase;
    #endregion

    #region Variables
    protected float stateTimer;
    protected bool isGrounded;
    protected bool isTouchingWall;
    private readonly string animationBool;
    #endregion

    public EnemyState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string animationBool)
    {
        this.enemyBase = _enemyBase;
        this.stateMachine = _stateMachine;
        this.animationBool = animationBool;
    }

    public virtual void CollisionChecks()
    {
        isGrounded = enemyBase.CheckIfGrounded();
        isTouchingWall = enemyBase.CheckIfTouchingWall();
    }

    public virtual void Enter()
    {
        CollisionChecks();
        enemyBase.Animator.SetBool(animationBool, true);
    }

    public virtual void LogicUpdate()
    {
        stateTimer -= Time.deltaTime;
    }

    public virtual void PhysicUpdate()
    {
        CollisionChecks();
    }

    public virtual void Exit()
    {
        enemyBase.Animator.SetBool(animationBool, false);
    }
}
