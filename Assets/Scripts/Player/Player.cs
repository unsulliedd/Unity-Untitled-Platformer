using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerStateMachine StateMachine { get; private set; }

    #region State References
    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }
    #endregion

    #region Component References
    public Animator Animator { get; private set; }
    public Rigidbody2D Rigidbody2D { get; private set; }
    public PlayerInputHandler InputHandler { get; private set; }
    #endregion

    void Awake()
    {
        StateMachine = new PlayerStateMachine();

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
}
