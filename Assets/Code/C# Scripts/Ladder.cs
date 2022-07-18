using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    FPSController player;
    void Start()
    {
        player = FindObjectOfType<FPSController>();
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && !player.IsOnLadder())
        {
            player.ToggleLadder();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && player.IsOnLadder())
        {
            player.ToggleLadder();
        }
    }
}
