/*
 * 
 * Author: George Bell
 * Since:  07-07-2022
 * Organisation: Newcastle University
 * 
*/
using UnityEngine;

public class CubeController : MonoBehaviour
{
    LevelController levelController;

    public float speed, jumpForce;
    public Rigidbody rb;
    bool jumping;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        levelController = FindObjectOfType<LevelController>();
    }

    private void Update()
    {
        if (levelController.IsGamePaused())
        {
            Vector3 direction = new Vector3(Input.GetAxisRaw("Vertical"), 0, -Input.GetAxisRaw("Horizontal"));
            gameObject.transform.Translate(direction.normalized * Time.deltaTime * speed);

            if (Input.GetKeyDown(KeyCode.Space) && !jumping)
            {
                jumping = true;
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("floor"))
        {
            jumping = false;
        }
    }


}