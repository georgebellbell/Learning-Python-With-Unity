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

    public override void TriggerEnter()
    {
        base.TriggerEnter();
        levelController.EndLevel(true);
    }

   
}
