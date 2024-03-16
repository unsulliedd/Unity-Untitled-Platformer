public class PlayerGroundedState : PlayerState
{
    public PlayerGroundedState(Player _player, PlayerStateMachine _stateMachine, string _animationBool) : base(_player, _stateMachine, _animationBool)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.firstJumpCompleted = false;
        player.JumpState.ResetJumps();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (jumpInput && isGrounded)
        {
            player.firstJumpCompleted = true;
            player.InputHandler.JumpInputHelper();
            stateMachine.ChangeState(player.JumpState);
        }
        else if (attackInput)
        {
            player.InputHandler.AttackInputHelper();
            stateMachine.ChangeState(player.AttackState);
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }
}
