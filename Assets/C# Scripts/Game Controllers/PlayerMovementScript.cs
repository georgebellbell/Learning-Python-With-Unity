using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    [SerializeField] CharacterController controller;

    [SerializeField] float speed = 12f;
    [SerializeField] float gravity = -9.81f;
    [SerializeField] float jumpHeight = 3f;

    [SerializeField] Transform groundCheck;
    [SerializeField] float groundDistance = 0.4f;
    [SerializeField] LayerMask groundMask;

    Vector3 velocity;
    [SerializeField] bool isGrounded;
    
    void Update()
    {
        UpdateJump();
        UpdateMovement();
        Gravity();

    }

    /// <summary>
    /// Check if player is on ground and if so, check if they want to jump
    /// </summary>
    private void UpdateJump()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (Input.GetButtonDown("Jump") && isGrounded && !Ladder.onLadder)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
    }

    /// <summary>
    /// Moves user on x and z axis while not on ladder
    /// Moves user on y axis while on ladder
    /// </summary>
    private void UpdateMovement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move;

        if (Ladder.onLadder)
        {
            move = transform.up * z;
        }
        else
        {
            move = transform.right * x + transform.forward * z;
        }

        controller.Move(move * speed * Time.deltaTime);

        
    }

    /// <summary>
    /// While not on ladder, gravity effect is created
    /// </summary>
    private void Gravity()
    {
        if (!Ladder.onLadder)
        {
            velocity.y += gravity * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);
        }
    }

    /// <summary>
    /// Retrieves current speed of player
    /// </summary>
    /// <returns>
    /// float speed, movement speed of the player
    /// </returns>
    public float GetPlayerSpeed()
    {
        return speed;
    }
}
