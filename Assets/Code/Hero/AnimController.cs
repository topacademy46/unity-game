using UnityEngine;

public class AnimController : MonoBehaviour
{
    public bool isIdle;
    public bool isRun;

    public bool isJumping;
    public bool isFalling;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (isIdle)
        {
            animator.Play("Idle");
        }
        else if (isRun)
        {
            animator.Play("Run");
        }
        else if (isJumping)
        {
            animator.Play("Jumping");
        }
        else if (isFalling)
        {
            animator.Play("Falling");
        }
    }
}
