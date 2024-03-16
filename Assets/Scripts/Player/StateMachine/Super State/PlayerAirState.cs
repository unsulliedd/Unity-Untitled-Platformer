using UnityEngine.EventSystems;

public class PlayerAirState : PlayerState
{
    public PlayerAirState(Player _player, PlayerStateMachine _stateMachine, string _animationBool) : base(_player, _stateMachine, _animationBool)
    {
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

        if (isGrounded)
            stateMachine.ChangeState(player.IdleState);

        if (jumpInput)
        {
            if (player.firstJumpCompleted && player.doubleJumpTimer < 0 && player.JumpState.CanDoubleJump())
            {
                player.doubleJumpTimer = player.doubleJumpCooldown;
                player.firstJumpCompleted = false;
                JumpState();
            }
            else if (player.coyoteJumpTimer > 0)
            {
                player.coyoteJumpTimer = player.coyoteTime;
                player.firstJumpCompleted = true;
                player.JumpState.ResetJumps();
                JumpState();
            }
            else
            {
                player.InputHandler.JumpInputHelper();
                return;
            }
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();

        if (xInput != 0)
            player.SetVelocity(xInput * player.moveSpeedInAir, player.Rigidbody2D.velocity.y);
    }

    private void JumpState()
    {
        player.InputHandler.JumpInputHelper();
        stateMachine.ChangeState(player.JumpState);
    }

}
