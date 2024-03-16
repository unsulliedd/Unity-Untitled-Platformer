using UnityEngine;

public class Player : SharedEntity
{
    public PlayerStateMachine StateMachine { get; private set; }

    #region State References
    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }
    public PlayerJumpState JumpState { get; private set; }
    public PlayerAirState AirState { get; private set; }
    public PlayerAttackState AttackState { get; private set; }
    #endregion

    #region Component References
    public PlayerInputHandler InputHandler { get; private set; }
    #endregion

    #region Variables
    [Header("Move Info")]
    public float moveSpeed = 10f;
    public float moveSpeedInAir = 7f;

    [Header("Jump Info")]
    public float jumpForce = 25;
    public int amountOfJumps = 2;
    public bool firstJumpCompleted;
    public float doubleJumpCooldown = 2.5f;
    public float doubleJumpTimer;
    public float coyoteTime = 0.2f;
    public float coyoteJumpTimer;

    #endregion

    protected override void Awake()
    {
        base.Awake();
        StateMachine = new PlayerStateMachine();

        IdleState = new PlayerIdleState(this, StateMachine, "Idle");
        MoveState = new PlayerMoveState(this, StateMachine, "Move");
        JumpState = new PlayerJumpState(this, StateMachine, "Jump");
        AirState = new PlayerAirState(this, StateMachine, "Jump");
        AttackState = new PlayerAttackState(this, StateMachine, "Attack");

        InputHandler = GetComponentInChildren<PlayerInputHandler>();
    }

    protected override void Start()
    {
        base.Start();
        StateMachine.Initialize(IdleState);
    }

    protected override void Update()
    {
        base.Update();
        StateMachine.currentState.LogicUpdate();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        StateMachine.currentState.PhysicUpdate();
    }

    public void UpdateJumpCounters()
    {
        if (CheckIfGrounded())
            coyoteJumpTimer = coyoteTime;
        else
            coyoteJumpTimer -= Time.deltaTime;

        doubleJumpTimer -= Time.deltaTime;
    }
}
