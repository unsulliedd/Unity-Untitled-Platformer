public class PlayerStateMachine
{
    public PlayerState currentState;

    public void Initialize(PlayerState _startState)
    {
        currentState = _startState;
        currentState.Enter();
    }

    public void ChangeState(PlayerState _newState)
    {
        currentState.Exit();
        currentState = _newState;
        currentState.Enter();
    }

    public void LogicUpdate()
    {
        currentState.LogicUpdate();
    }

    public void PhysicUpdate()
    {
        currentState.PhysicUpdate();
    }
}
