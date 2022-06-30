using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Light : Button
{
    [SerializeField] FinishLight linkedLight;
    [SerializeField] bool buttonActivated = false;

    public override void ActivateButton()
    {
        base.ActivateButton();
        Debug.Log("Light Button");
        linkedLight.ActivateLight();
    }

    public bool IsButtonActive()
    {
        return buttonActivated;
    }
}
