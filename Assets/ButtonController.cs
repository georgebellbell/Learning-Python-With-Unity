using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    [SerializeField] Button button;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
        {
            GameObject hitObject = hit.collider.gameObject;

            if (hitObject.CompareTag("button") && hit.distance < 5.0f)
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
