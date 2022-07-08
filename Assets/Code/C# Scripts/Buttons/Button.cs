/*
 * 
 * Author: George Bell
 * Since:  07-07-2022
 * Organisation: Newcastle University
 * 
*/
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] Material defaultButtonMaterial;

    Renderer buttonRenderer;
    Animator animator;

    private void Start()
    {
        buttonRenderer  = GetComponent<Renderer>();
        animator        = GetComponent<Animator>();
    }
    public void HoverOverButton()
    {
        buttonRenderer.material.color = Color.green;
    }

    public virtual void HoverOffButton()
    {
        buttonRenderer.material = defaultButtonMaterial;
    }

    public virtual void ActivateButton()
    {
        animator.SetTrigger("Press Button");
    }

   
}
