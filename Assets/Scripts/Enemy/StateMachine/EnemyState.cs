public class EnemyState 
{
    #region References
    protected EnemyStateMachine stateMachine;
    protected Enemy enemy;
    #endregion

    #region Variables
    protected bool isGrounded;
    private readonly string animationBool;
    #endregion

    public EnemyState(Enemy _enemy, EnemyStateMachine _stateMachine, string animationBool)
    {
        this.enemy = _enemy;
        this.stateMachine = _stateMachine;
        this.animationBool = animationBool;
    }

    public virtual void Enter()
    {
        enemy.Animator.SetBool(animationBool, true);
    }

    public virtual void LogicUpdate()
    {
    }

    public virtual void PhysicUpdate()
    {
    }

    public virtual void Exit()
    {
        enemy.Animator.SetBool(animationBool, false);
    }
}
