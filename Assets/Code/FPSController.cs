using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour
{
    [SerializeField] GameObject camera;

    Rigidbody rb;

    [SerializeField] float playerSpeed;
    [SerializeField] float walkSpeed = 0.1f;
    float sprintSpeed = 4f;
    bool isSprinting = false, isJumping = false;

    [SerializeField] float mouseSensitivity = 2f;
    float yRotation, xRotation;

    float jumpHeight = 5f;

   

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerSpeed = walkSpeed;

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        rb.MoveRotation(rb.rotation * Quaternion.Euler(new Vector3(0, Input.GetAxis("Mouse X") * mouseSensitivity, 0)));
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
    }
}
