using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Component")]
    Rigidbody2D rb;
    Animator animator;

    [Header("Stat")]
    [SerializeField] private float moveSpeed;


    public Vector2 direction { get; private set; }
    public Vector2 lastDirection { get; private set; }

    public bool IsAttacking { get; set; }
    public bool IsDead { get; set; }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Move();

    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
    }

    private void Move()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        direction = new Vector2(horizontalInput, verticalInput).normalized;

        if (direction != Vector2.zero)
        {
            lastDirection = direction;
        }

        animator.SetFloat("moveX", lastDirection.x);
        animator.SetFloat("moveY", lastDirection.y);
        animator.SetBool("isMove", direction != Vector2.zero);
    }



    public void Die()
    {
        animator.SetBool("isDead", true);
    }




}