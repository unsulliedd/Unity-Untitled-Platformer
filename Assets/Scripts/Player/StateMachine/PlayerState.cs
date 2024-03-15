public class PlayerState
{
    #region References
    protected PlayerStateMachine stateMachine;
    protected Player player;
    #endregion
    #region Input Variables
    protected float xInput;
    #endregion
    #region Variables
    private readonly string animationBool;
    #endregion

    // Constructor
    public PlayerState(Player _player, PlayerStateMachine _stateMachine, string _animationBool)
    {
        this.player = _player;
        this.stateMachine = _stateMachine;
        this.animationBool = _animationBool;
    }

    public virtual void Enter()
    {
        player.Animator.SetBool(animationBool, true);
    }

    public virtual void LogicUpdate()
    {
        xInput = player.InputHandler.HorizontalInput.x;
    }

    public virtual void PhysicUpdate()
    {

    }

    public virtual void Exit()
    {
        player.Animator.SetBool(animationBool, false);
    }
}
