using UnityEngine;

public class SharedEntity : MonoBehaviour
{
    #region Component References
    public Animator Animator { get; private set; }
    public Rigidbody2D Rigidbody2D { get; private set; }
    #endregion

    protected virtual void Awake()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
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
}
