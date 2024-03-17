using UnityEngine;

public class EnemyGoblin : Enemy
{
    #region States
    public GoblinIdleState idleState { get; private set; }
    public GoblinPatrolState patrolState { get; private set; }
    public GoblinChaseState chaseState { get; private set; }
    public GoblinAttackState attackState { get; private set; }
    #endregion

    [Header("Goblin Attributes")]
    public float moveSpeed = 7f;
    public float idleTime = 1f;


    protected override void Awake()
    {
        base.Awake();
        idleState = new GoblinIdleState(this, stateMachine, "Idle", this);
        patrolState = new GoblinPatrolState(this, stateMachine, "Move", this);
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
