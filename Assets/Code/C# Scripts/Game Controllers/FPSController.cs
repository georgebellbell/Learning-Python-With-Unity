/*
 * 
 * Author: George Bell
 * Since:  07-07-2022
 * Organisation: Newcastle University
 * 
*/
using UnityEngine;

public class FPSController : MonoBehaviour
{
    [SerializeField] GameObject camera;
    [SerializeField] float playerSpeed;
    [SerializeField] float walkSpeed = 0.1f;
    [SerializeField] float sprintSpeed = 0.2f;
    [SerializeField] bool isJumping = false;
    [SerializeField] float mouseSensitivity = 2f;

    float jumpHeight = 5f;

    bool onLadder;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerSpeed = walkSpeed;

        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float yRotate = Mathf.Clamp(-Input.GetAxis("Mouse Y") * mouseSensitivity, -90, 90);
        camera.transform.Rotate(new Vector3(yRotate, 0, 0));

        if (Input.GetKey(KeyCode.LeftShift))
        {
            playerSpeed = sprintSpeed;
        }
        else
        {
            playerSpeed = walkSpeed;
        }    
    }

    private void FixedUpdate()
    {
        rb.MoveRotation(rb.rotation * Quaternion.Euler(new Vector3(0, Input.GetAxis("Mouse X") * mouseSensitivity, 0)));

        if (!onLadder)
        {
            MoveUpLadder();
        }
        else
        {
            rb.MovePosition(transform.position + (transform.up * Input.GetAxis("Vertical") * playerSpeed));

        }
    }

    private void MoveUpLadder()
    {
        rb.MovePosition(transform.position + (transform.forward * Input.GetAxis("Vertical") * playerSpeed) + (transform.right * Input.GetAxis("Horizontal") * playerSpeed));

        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            isJumping = true;
            rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("floor"))
        {
            isJumping = false;
        }
        if (collision.gameObject.CompareTag("ladder"))
        {
            onLadder = true;
            rb.useGravity = false;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("ladder"))
        {
            onLadder = false;
            rb.useGravity = true;
        }
    }

}