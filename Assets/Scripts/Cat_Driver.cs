using UnityEngine;

public class Cat_Driver : MonoBehaviour
{
    [SerializeField] float catSpeed = 5f;
    [SerializeField] Animator animator;

    public FixedJoystick Joystick;
    public Rigidbody2D rb;

    private bool left;
    private bool right;
    private bool down;

    void FixedUpdate()
    {
        // Keyboard
        float keyboardX = Input.GetAxisRaw("Horizontal");
        float keyboardY = Input.GetAxisRaw("Vertical");

        // Joystick
        float joystickX = Joystick.Horizontal;
        float joystickY = Joystick.Vertical;

        // Combine keyboard + joystick
        float x = Mathf.Abs(joystickX) > 0.1f ? joystickX : keyboardX;
        float y = Mathf.Abs(joystickY) > 0.1f ? joystickY : keyboardY;

        Vector2 direction = new Vector2(x, y).normalized;

        // Movement
        rb.linearVelocity = direction * catSpeed;

        // Animation
        left = false;
        right = false;
        down = false;

        if (y < -0.1f)
        {
            down = true;
        }
        else if (x < -0.1f)
        {
            left = true;
        }
        else if (x > 0.1f)
        {
            right = true;
        }

        animator.SetBool("left", left);
        animator.SetBool("right", right);
        animator.SetBool("down", down);

        // Boundary
        Vector2 position = rb.position;
        position.x = Mathf.Clamp(position.x, -30f, 30f);
        position.y = Mathf.Clamp(position.y, -30f, 30f);
        rb.position = position;
    }
}