using UnityEngine;

public class EnemyGiant : Enemy
{
    #region States
    public GiantIdleState idleState { get; private set; }
    public GiantPatrolState patrolState { get; private set; }
    public GiantChaseState chaseState { get; private set; }
    public GiantAttackState attackState { get; private set; }
    #endregion

    [Header("Giant Attributes")]
    public float moveSpeed = 4f;
    public float idleTime = 2f;

    protected override void Awake()
    {
        base.Awake();
        idleState = new GiantIdleState(this, stateMachine, "Idle", this);
        patrolState = new GiantPatrolState(this, stateMachine, "Move", this);
    }

    protected override void Start()
    {
        base.Start();
        stateMachine.Initialize(idleState);
    }

    protected override void Update()
    {
        base.Update();
    }
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }
}
