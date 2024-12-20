using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float jumpForce;
    private AnimController animController;

    void Start()
    {
        animController = GetComponent<AnimController>();
    }

    void Update()
    {
        if (Mathf.Abs(rb.velocity.x) < 0.1f && Mathf.Abs(rb.velocity.y) < 0.1f)
        {
            animController.isIdle = true;
        }
        else
        {
            animController.isIdle = false;
        }

        if (rb.velocity.y > 0)
        {
            animController.isJumping = true;
            animController.isFalling = false;
        }
        else if (rb.velocity.y < 0)
        {
            animController.isFalling = true;
            animController.isJumping = false;
        }
        else
        {
            animController.isJumping = false;
            animController.isFalling = false;
        }

        Move();
        Jump();
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            animController.isRun = true;
            animController.isIdle = false;

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
            animController.isRun = false;
        }
    }




    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && rb.velocity.y == 0)
        {

            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }
}
