using UnityEngine;

public class Player : MonoBehaviour
{
    #region References
    public PlayerStateMachine StateMachine { get; private set; }
    public Animator Animator { get; private set; }
    #endregion

    void Awake()
    {
        StateMachine = new PlayerStateMachine();

        Animator = GetComponentInChildren<Animator>();
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
