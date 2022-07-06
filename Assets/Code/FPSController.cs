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
    float yChange;

    bool onLadder;
   

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
        float yRotate = Mathf.Clamp(-Input.GetAxis("Mouse Y") * mouseSensitivity, -90, 90);
        //Debug.Log(yRotate);
        camera.transform.Rotate(new Vector3(yRotate, 0, 0));
        
    }

    private void FixedUpdate()
    {
        rb.MoveRotation(rb.rotation * Quaternion.Euler(new Vector3(0, Input.GetAxis("Mouse X") * mouseSensitivity, 0)));

        if (!onLadder)
        {
            rb.MovePosition(transform.position + (transform.forward * Input.GetAxis("Vertical") * playerSpeed) + (transform.right * Input.GetAxis("Horizontal") * playerSpeed));

            if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
            {
                isJumping = true;
                rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
            }
        }
        else
        {
            rb.MovePosition(transform.position + (transform.up * Input.GetAxis("Vertical") * playerSpeed));

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
