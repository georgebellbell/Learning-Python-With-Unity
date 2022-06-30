using UnityEngine;
using System.Collections;

public class CubeController : MonoBehaviour
{
    public float speed, jumpForce;
    public Rigidbody rb;
    bool jumping;

    bool alive = true;

    LevelController levelController;

   

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        levelController = FindObjectOfType<LevelController>();
    }

    private void Update()
    {
        if (levelController.GetGameStatus())
        {
            Debug.Log(levelController.GetGameStatus());
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            Vector3 direction = new Vector3(vertical, 0, -horizontal);
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

    public void PlayerDied()
    {
        alive = false;
        levelController.SetGameStatus(false);
    }

}