using UnityEngine;

public class SharedEntity : MonoBehaviour
{
    #region Component References
    public Animator Animator { get; private set; }
    public Rigidbody2D Rigidbody2D { get; private set; }
    private SpriteRenderer _spriteRenderer;
    #endregion

    [Header("Flip Info")]
    public int facingDirection = 1;
    [SerializeField] private bool _isFacingRight = true;

    [Header("Collision Check")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private Transform wallCheck;
    [SerializeField] private float wallCheckDistance;
    [SerializeField] protected Transform attackHitBox;
    [SerializeField] protected float attackHitBoxRadius;

    [Header("Character Info")]
    public int health = 100;
    public int damage = 20;
    public string targetHitTag = "Enemy";

    protected virtual void Awake()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponentInChildren<Animator>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    protected virtual void Start()
    {

    }

    protected virtual void Update()
    {

    }

    protected virtual void FixedUpdate()
    {

    }

    public void SetZeroVelocity() => Rigidbody2D.velocity = Vector2.zero;

    public void SetVelocity(float xVelocity, float yVelocity)
    {
        Rigidbody2D.velocity = new Vector2(xVelocity, yVelocity);
        FlipController(xVelocity);
    }

    public virtual void FlipController(float _xVelocity)
    {
        if (_xVelocity < 0 && _isFacingRight)
            Flip();
        else if (_xVelocity > 0 && !_isFacingRight)
            Flip();
    }

    public virtual void Flip()
    {
        transform.Rotate(0f, 180f, 0f);
        _isFacingRight = !_isFacingRight;
        facingDirection *= -1;
    }

    public virtual void TakeDamage(int damage)
    {
        health -= damage;

        _spriteRenderer.color = Color.red;
        Invoke("ResetColor", 0.1f);

        // TODO : Death animation
        if (health <= 0)
            gameObject.SetActive(false);
    }

    public virtual bool CheckIfGrounded() => Physics2D.OverlapCircle(groundCheck.transform.position, groundCheckDistance, groundLayer);
    public virtual bool CheckIfTouchingWall() => Physics2D.Raycast(wallCheck.position, Vector2.right * facingDirection, wallCheckDistance, groundLayer);

    public virtual Collider2D[] CheckIfAttackHit() => Physics2D.OverlapCircleAll(attackHitBox.transform.position, attackHitBoxRadius);

    private void ResetColor() => _spriteRenderer.color = Color.white;

    public virtual void AttackHit()
    {
        Collider2D[] hitObjects = CheckIfAttackHit();
        foreach (var hitObject in hitObjects)
        {
            if (hitObject.CompareTag(targetHitTag))
            {
                hitObject.GetComponent<SharedEntity>().TakeDamage(damage);

                Debug.Log("Hit : " + hitObject.name + " with " + damage + " damage and remaining health : " + hitObject.GetComponent<SharedEntity>().health);
            }
        }
    }

    protected virtual void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckDistance);
        Gizmos.DrawLine(wallCheck.position, new Vector2(wallCheck.position.x + wallCheckDistance, wallCheck.position.y));
        Gizmos.DrawWireSphere(attackHitBox.position, attackHitBoxRadius);
    }
}
