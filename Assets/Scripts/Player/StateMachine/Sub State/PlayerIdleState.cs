public class PlayerIdleState : PlayerGroundedState
{
    public PlayerIdleState(Player _player, PlayerStateMachine _stateMachine, string _animationBool) : base(_player, _stateMachine, _animationBool)
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

        if (xInput != 0)
            stateMachine.ChangeState(player.MoveState);
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }
}
