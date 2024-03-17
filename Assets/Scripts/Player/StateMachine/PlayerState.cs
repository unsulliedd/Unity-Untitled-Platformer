using UnityEngine.UI;

public class PlayerState
{
    #region References
    protected PlayerStateMachine stateMachine;
    protected Player player;
    #endregion
    #region Input Variables
    protected float xInput;
    protected bool jumpInput;
    protected bool attackInput;
    #endregion
    #region Variables
    protected bool isGrounded;
    protected bool animationTrigger;
    private readonly string animationBool;
    #endregion

    // Constructor
    public PlayerState(Player _player, PlayerStateMachine _stateMachine, string _animationBool)
    {
        this.player = _player;
        this.stateMachine = _stateMachine;
        this.animationBool = _animationBool;
    }

    public virtual void CollisionChecks()
    {
        isGrounded = player.CheckIfGrounded();
    }

    public virtual void Enter()
    {
        CollisionChecks();
        animationTrigger = false;
        player.Animator.SetBool(animationBool, true);
    }

    public virtual void LogicUpdate()
    {
        player.UpdateJumpCounters();

        xInput = player.InputHandler.HorizontalInput.x;
        jumpInput = player.InputHandler.JumpInput;
        attackInput = player.InputHandler.AttackInput;

        player.Animator.SetFloat("yVelocity", player.Rigidbody2D.velocity.y);
    }

    public virtual void PhysicUpdate()
    {
        CollisionChecks();
        if (!isGrounded)
            player.StateMachine.ChangeState(player.AirState);
    }

    public virtual void Exit()
    {
        player.Animator.SetBool(animationBool, false);
    }

    public virtual void AnimationFinishTrigger() => animationTrigger = true;
}
