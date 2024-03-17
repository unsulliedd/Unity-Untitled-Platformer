public class Enemy : SharedEntity
{
    public EnemyStateMachine stateMachine;

    protected override void Awake()
    {
        base.Awake();
        stateMachine = new EnemyStateMachine();
    }

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
        stateMachine.currentState.LogicUpdate();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }
}
