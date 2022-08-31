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
    [SerializeField] float speed, jumpForce;
    
   // LevelController levelController;
    Rigidbody rb;
    bool jumping;
    
    private void Start()
    {
        //levelController = FindObjectOfType<LevelController>();
        rb = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// If game is not paused, player can move and jump
    /// </summary>
    private void Update()
    {
        if (!LevelController.GameIsPaused)
        {
            MovementAndJumping();
        }
    }

    /// <summary>
    /// Player moves with WASD and jumps with space, unless they are already jumping
    /// </summary>
    private void MovementAndJumping()
    {
        Vector3 direction = new Vector3(Input.GetAxisRaw("Vertical"), 0, -Input.GetAxisRaw("Horizontal"));
        gameObject.transform.Translate(direction.normalized * Time.deltaTime * speed);

        if (Input.GetKeyDown(KeyCode.Space) && !jumping)
        {
            jumping = true;
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    /// <summary>
    /// If player hits floor, they are able to jump again
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("floor"))
        {
            jumping = false;
        }
    }


}