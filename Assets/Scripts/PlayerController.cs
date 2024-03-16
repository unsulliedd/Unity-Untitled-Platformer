using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class PlayerController : MonoBehaviour
{
    #region Fields
    [Header("Player Properties")]

    [SerializeField]
    private int _health = 100;
    [SerializeField]
    private int _attackPower = 10;

    [SerializeField]
    private float _walkSpeed = 5.0f;
    [SerializeField]
    private float _runSpeed = 10.0f;
    [SerializeField]
    private float _jumpForce = 5.0f;

    [SerializeField]
    private bool _isGrounded = false;
    [SerializeField]
    private bool _hasDoubleJump = false;
    private bool _hasJumped = false;

    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rb;
    private PlayerInputActions _playerActions;
    private Animator _animator;
    #endregion

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

        _playerActions = new PlayerInputActions();
        _playerActions.Enable();
        _playerActions.Player.Jump.performed += Jump;
    }

    private void FixedUpdate()
    {
        Move();
    }

    #region Public Methods
    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            // Death logic
        }
    }

    public void BoostSpeed(float speedBoost)
    {

    }

    public void BoostJump(float jumpBoost)
    {

    }

    public void BoostAttackPower(int attackBoost)
    {

    }
    #endregion

    #region Movement
    private void Jump(CallbackContext callbackContext)
    {
        if (_isGrounded)
        {
            _animator.SetTrigger("Jumped");

            _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            _isGrounded = false;
            _hasJumped = true;
        }
        else if (_hasDoubleJump)
        {
            _animator.SetTrigger("DoubleJumped");
            _hasDoubleJump = false;

            _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
    }

    private void Move()
    {
        Vector2 movementInput = _playerActions.Player.Movement.ReadValue<Vector2>();
        float isRunning = _playerActions.Player.Run.ReadValue<float>();
        float speed = _walkSpeed;

        if (isRunning != 0 && movementInput != Vector2.zero)
        {            
            _animator.SetFloat("Speed", Mathf.Abs(movementInput.x) + 1);
            speed = _runSpeed;
        }
        else
        {
            _animator.SetFloat("Speed", Mathf.Abs(movementInput.x));
        }

        transform.Translate(movementInput * speed * Time.deltaTime);

        // Gidiþ yönüne göre sprite'ý çevir
        if (movementInput.x != 0)
        {
            _spriteRenderer.flipX = movementInput.x < 0;
        }
    }
    #endregion

    #region Collision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (_hasJumped)
                _animator.SetTrigger("Landed");

            _isGrounded = true;
            _hasDoubleJump = true;
            _hasJumped = false;
        }
    }
    #endregion
}
