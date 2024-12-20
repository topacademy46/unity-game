using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    private Rigidbody2D rb;
    private InputService inputService;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        inputService = GetComponent<InputService>();
        animator = GetComponent<Animator>();
    }
    void FixedUpdate()
    {
        Move();
    }

    void Update()
    {
        Jump();
        UpdateAnimator();
    }

    private void Move()
    {
        rb.velocity = new Vector2(inputService.getHorizontalDirection() * moveSpeed, rb.velocity.y);
    }

    private void Jump()
    {
        if (inputService.getJumpKeyPressed() && rb.velocity.y == 0)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }

    private void UpdateAnimator()
    {
        animator.SetFloat("SpeedX", Mathf.Abs(rb.velocity.x));
        animator.SetFloat("SpeedY", rb.velocity.y);
        animator.SetBool("isJumpKeyPressed", inputService.getJumpKeyPressed());
    }
}
