using UnityEngine;

public class Enemy : SharedEntity
{
    public EnemyStateMachine stateMachine;
    public LayerMask playerLayer;
    public Transform playerCheck;
    public float lookRange;

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

    public virtual RaycastHit2D CheckForPlayerInSight() => Physics2D.Raycast(playerCheck.position, Vector2.right * facingDirection, lookRange, playerLayer);
}
