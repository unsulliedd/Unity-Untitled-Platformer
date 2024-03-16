using UnityEngine;

public class Player : MonoBehaviour
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
    public Animator Animator { get; private set; }
    public Rigidbody2D Rigidbody2D { get; private set; }
    public PlayerInputHandler InputHandler { get; private set; }
    #endregion

    #region Variables
    [Header("Move Info")]
    public float moveSpeed = 10f;
    public float moveSpeedInAir = 7f;
    public int facingDirection = 1;
    [SerializeField] private bool _isFacingRight = true;

    [Header("Jump Info")]
    public float jumpForce = 25;
    public int amountOfJumps = 2;
    public bool firstJumpCompleted;
    public float doubleJumpCooldown = 2.5f;
    public float doubleJumpTimer;
    public float coyoteTime = 0.2f;
    public float coyoteJumpTimer;

    [Header("Collision Check")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float groundCheckDistance = 0.45f;
    #endregion

    void Awake()
    {
        StateMachine = new PlayerStateMachine();

        IdleState = new PlayerIdleState(this, StateMachine, "Idle");
        MoveState = new PlayerMoveState(this, StateMachine, "Move");
        JumpState = new PlayerJumpState(this, StateMachine, "Jump");
        AirState = new PlayerAirState(this, StateMachine, "Jump");
        AttackState = new PlayerAttackState(this, StateMachine, "Attack");

        Animator = GetComponentInChildren<Animator>();
        Rigidbody2D = GetComponent<Rigidbody2D>();
        InputHandler = GetComponentInChildren<PlayerInputHandler>();
    }

    void Start()
    {
        StateMachine.Initialize(IdleState);
    }

    void Update()
    {
        StateMachine.currentState.LogicUpdate();
    }

    void FixedUpdate()
    {
        StateMachine.currentState.PhysicUpdate();
    }

    public void SetZeroVelocity() => Rigidbody2D.velocity = Vector2.zero;

    public void SetVelocity(float xVelocity, float yVelocity)
    {
        Rigidbody2D.velocity = new Vector2(xVelocity, yVelocity);
        FlipController();
    }

    private void FlipController()
    {
        if (InputHandler.HorizontalInput.x < 0 && _isFacingRight)
            Flip();
        else if (InputHandler.HorizontalInput.x > 0 && !_isFacingRight)
            Flip();
    }

    private void Flip()
    {
        transform.Rotate(0f, 180f, 0f);
        _isFacingRight = !_isFacingRight;
        facingDirection *= -1;
    }

    public void UpdateJumpCounters()
    {
        if (CheckIfGrounded())
            coyoteJumpTimer = coyoteTime;
        else
            coyoteJumpTimer -= Time.deltaTime;

        doubleJumpTimer -= Time.deltaTime;
    }

    public bool CheckIfGrounded() => Physics2D.OverlapCircle(groundCheck.transform.position, groundCheckDistance, groundLayer);

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckDistance);
    }
}
