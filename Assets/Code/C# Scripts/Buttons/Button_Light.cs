/*
 * 
 * Author: George Bell
 * Since:  07-07-2022
 * Organisation: Newcastle University
 * 
*/
using UnityEngine;

public class Button_Light : Button
{
    [SerializeField] FinishLight linkedLight;
    [SerializeField] bool buttonActivated = false;

    public override void ActivateButton()
    {
        base.ActivateButton();
        linkedLight.ActivateLight();
    }

    public bool IsButtonActive()
    {
        return buttonActivated;
    }
}
