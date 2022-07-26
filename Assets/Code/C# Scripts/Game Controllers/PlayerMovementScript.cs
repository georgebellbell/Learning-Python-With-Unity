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
    [SerializeField] bool onLadder;
    
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move;

        if (onLadder)
        {
            move = transform.up * z;
        }
        else
        {
            move = transform.right * x + transform.forward * z;
        }

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded && !onLadder)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        if (!onLadder)
        {
            velocity.y += gravity * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);
        }
        

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ladder"))
        {
            onLadder = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("ladder"))
        {
            onLadder = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ladder"))
        {
            onLadder = false;
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
