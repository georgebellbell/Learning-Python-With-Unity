/*
 * 
 * Author: George Bell
 * Since:  07-07-2022
 * Organisation: Newcastle University
 * 
*/
using UnityEngine;

public class Gate_Finish : Gate
{
    [SerializeField] FinishLight[] finishLights;
    [SerializeField] LevelController levelController;

    void Start()
    {
        finishLights = FindObjectsOfType<FinishLight>();
        levelController = FindObjectOfType<LevelController>();
    }

    /// <summary>
    /// Check all lights and all are active, gate will open
    /// </summary>
    public void CheckLights()
    {
        foreach (FinishLight light in finishLights)
        {
            if (light.IsLightActive())
            {
                gateOpen = true;
            }
            else
            {
                gateOpen = false;
                break;
            }
        }

        if (gateOpen)
        {
            OpenGate();
        }
    }

    /// <summary>
    /// If gate is open, upon entering the game is won
    /// </summary>
    public override void TriggerEnter()
    {
        base.TriggerEnter();
        levelController.EndLevel(true);
    }

   
}
