using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RisingPlatform : MonoBehaviour
{
    [SerializeField] GameObject errorMessage;

    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void ActivatePlatform()
    {
        animator.SetTrigger("RaisePlatform");

        if (errorMessage)
        {
            errorMessage.SetActive(true);
        }
    }
}
