using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShadow : Enemy
{
    #region States
    public ShadowIdleState idleState { get; private set; }
    public ShadowPatrolState patrolState { get; private set; }
    public ShadowChaseState chaseState { get; private set; }
    public ShadowAttackState attackState { get; private set; }
    #endregion

    [Header("Shadow Attributes")]
    public float moveSpeed = 10f;
    public float idleTime = 0.5f;

    protected override void Awake()
    {
        base.Awake();
        idleState = new ShadowIdleState(this, stateMachine, "Idle", this);
        patrolState = new ShadowPatrolState(this, stateMachine, "Move", this);
        attackState = new ShadowAttackState(this, stateMachine, "Attack", this);
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
