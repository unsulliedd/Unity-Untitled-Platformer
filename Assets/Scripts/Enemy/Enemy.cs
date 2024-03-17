using UnityEngine;

public class Enemy : SharedEntity
{
    public EnemyStateMachine stateMachine;

    private Player _player;
    public float _attackCooldown = 2f;

    protected override void Awake()
    {
        base.Awake();

        _player = GameObject.Find("Player").GetComponent<Player>();

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

        if (_attackCooldown > 0)
        {
            _attackCooldown -= Time.deltaTime;
        }
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    public bool PlayerInRange()
    {
        if (Mathf.Abs(_player.transform.position.x - transform.position.x) < 5f)
        {
            return true;
        }

        return false;
    }

    public bool CanAttack()
    {
        bool canHitPlayer = false;

        Collider2D[] hitObjects = CheckIfAttackHit();

        foreach (var hitObject in hitObjects)
        {
            if (hitObject.CompareTag(targetHitTag))
            {
                canHitPlayer = true;
            }
        }

        if (_attackCooldown <= 0 && canHitPlayer)
        {
            return true;
        }

        return false;
    }

    public override void AttackHit()
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

        _attackCooldown = 2f;
    }

    public void MoveTowardsPlayer()
    {
        if (transform.position.x < _player.transform.position.x)
        {
            SetVelocity(1f, Rigidbody2D.velocity.y);
        }
        else
        {
            SetVelocity(-1f, Rigidbody2D.velocity.y);
        }
    }
}
