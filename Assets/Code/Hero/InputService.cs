using UnityEngine;

public class InputService : MonoBehaviour
{
    private float horizontalDirection;
    [SerializeField] private bool jumpKeyPressed;

    public float getHorizontalDirection()
    {
        horizontalDirection = 0;
        if (Input.GetKey(KeyCode.D))
        {
            horizontalDirection = 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            horizontalDirection = -1;
        }

        return horizontalDirection;
    }

    public bool getJumpKeyPressed()
    {
        jumpKeyPressed = false;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpKeyPressed = true;
            return jumpKeyPressed;
        }
        return jumpKeyPressed;
    }
}
