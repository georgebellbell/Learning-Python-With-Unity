using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate_Finish : Gate
{
    [SerializeField] FinishLight[] finishLights;

    void Start()
    {
        finishLights = FindObjectsOfType<FinishLight>();
    }

    public void CheckLights()
    {
        foreach (FinishLight light in finishLights)
        {
            Debug.Log("name: " + light.gameObject.name + " status: " + light.IsLightActive());
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
        Debug.Log("YOU WON");
    }

   
}
