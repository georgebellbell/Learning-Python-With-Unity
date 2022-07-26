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

    /// <summary>
    /// If button is in user crosshair, it highlights green
    /// </summary>
    public void HoverOverButton()
    {
        buttonRenderer.material.color = Color.green;
    }

    /// <summary>
    /// if button is not in user crosshair anymore, it returns to normal colour
    /// </summary>
    public virtual void HoverOffButton()
    {
        buttonRenderer.material = defaultButtonMaterial;
    }

    /// <summary>
    /// Runs functionality of a button alongside a button press animation
    /// </summary>
    public virtual void ActivateButton()
    {
        animator.SetTrigger("Press Button");
    }
}
