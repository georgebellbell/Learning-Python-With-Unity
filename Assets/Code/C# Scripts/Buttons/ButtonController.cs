/*
 * 
 * Author: George Bell
 * Since:  07-07-2022
 * Organisation: Newcastle University
 * 
*/
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    [SerializeField] Button button;

    void Update()
    {
        if (button && Input.GetKeyUp(KeyCode.Mouse0))
        {
            button.ActivateButton();
        }
    }

    private void FixedUpdate()
    {
        CheckForButton();
    }

    private void CheckForButton()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, GetComponent<Transform>().forward, out hit))
        {
            GameObject hitObject = hit.collider.gameObject;

            if (hitObject.tag.Contains("button") && hit.distance < 5.0f)
            {
                button = hitObject.GetComponent<Button>();
                button.HoverOverButton();
            }
            else
            {
                if (button)
                {
                    button.HoverOffButton();
                    button = null;
                }
            }
        }
    }
}
