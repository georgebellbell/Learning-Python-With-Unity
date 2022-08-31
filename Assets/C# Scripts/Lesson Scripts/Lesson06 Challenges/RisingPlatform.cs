/*
 * 
 * Author: George Bell
 * Since:  07-07-2022
 * Organisation: Newcastle University
 * 
*/
using UnityEngine;

public class RisingPlatform : MonoBehaviour
{
    [SerializeField] GameObject errorMessage;

    Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    /// <summary>
    /// If called, platform rises through animation
    /// If pillar has error message, it is activated
    /// </summary>
    public void ActivatePlatform()
    {
        animator.SetTrigger("RaisePlatform");

        if (errorMessage)
        {
            errorMessage.SetActive(true);
        }
    }
}
