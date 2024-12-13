using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float jumpForce;


    void Update()
    {
        if (rb.velocity.x == 0 && rb.velocity.y == 0)
        {
            animator.SetBool("isIdle", true);
        }
        else
        {
            animator.SetBool("isIdle", false);
        }
        Move();
        Jump();
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            animator.SetBool("isRun", true);
            if (Input.GetKey(KeyCode.D))
            {
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
                transform.position = new Vector3(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * -1, transform.localScale.y, transform.localScale.z);
                transform.position = new Vector3(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y, transform.position.z);
            }
        }
        else
        {
            animator.SetBool("isRun", false);
        }
    }




    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && rb.velocity.y == 0)
        {
            animator.SetBool("isJump", true);
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
        else
        {
            animator.SetBool("isJump", false);
        }
    }
}
