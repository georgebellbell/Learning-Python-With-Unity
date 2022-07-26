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
    /// <summary>
    /// overrides AcitvateButton to activate a specific light of the finish gate
    /// </summary>
    public override void ActivateButton()
    {
        base.ActivateButton();
        linkedLight.ActivateLight();
    }
}
