using UnityEngine;

public class Ladder : MonoBehaviour
{
    PlayerMovementScript playerMovement;
    Transform playerTransform;

    float speedOnLadder = 3.2f;
    public static bool onLadder;
    
    void Start()
    {
        playerMovement = GetComponent<PlayerMovementScript>();
        playerTransform = playerMovement.gameObject.transform;
        onLadder = false;

        speedOnLadder = 0.8f * playerMovement.GetPlayerSpeed();
    }

    /// <summary>
    /// If on ladder, player moves up and down using W and S keys
    /// </summary>
    void Update()
    {
        if (onLadder == true && Input.GetKey(KeyCode.W))
        {
            playerTransform.transform.position += Vector3.up * speedOnLadder * Time.deltaTime;
        }
        if (onLadder == true && Input.GetKey(KeyCode.S))
        {
            playerTransform.transform.position += Vector3.down * speedOnLadder * Time.deltaTime;
        }
    }

    /// <summary>
    /// If player moves into ladder collider, normal movement is disabled and vertical movement is enabled
    /// </summary>
    /// <param name="col"></param>
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("ladder"))
        {
            playerMovement.enabled = false;
            onLadder = !onLadder;
        }
    }

    /// <summary>
    /// If player moves out of ladder collider, normal movement is enabled and vertical movement is disabled
    /// </summary>
    /// <param name="col"></param>
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.CompareTag("ladder"))
        {
            playerMovement.enabled = true;
            onLadder = !onLadder;
        }
    }

   
}
