using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    Animator animator;
    Renderer renderer;
    private void Start()
    {
        renderer = GetComponent<Renderer>();
        animator = GetComponent<Animator>();
    }
    public void HoverOverButton()
    {
        renderer.material.color = Color.green;
    }

    public void HoverOffButton()
    {
        renderer.material.color = Color.red;
    }

    public virtual void ActivateButton()
    {
        Debug.Log("You Activated a Button");
        animator.SetTrigger("Press Button");
        
    }

   
}
