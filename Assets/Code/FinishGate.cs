using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishGate : MonoBehaviour
{
    [SerializeField] FinishLight[] finishLights;

    [SerializeField] bool gateOpen;

    [SerializeField] Material gateOpenMaterial;
    // Start is called before the first frame update
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

    private void OpenGate()
    {
        GetComponent<Renderer>().material = gateOpenMaterial;
        GetComponent<Collider>().isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("YOU WON");
        }
    }
}
