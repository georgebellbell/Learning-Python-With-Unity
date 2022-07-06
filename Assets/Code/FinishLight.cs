using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLight : MonoBehaviour
{
    bool lightActivated = false;

    [SerializeField] Material on, off;

    Gate_Finish finishGate;
    private void Start()
    {
        finishGate = FindObjectOfType<Gate_Finish>();
    }
    public void ActivateLight()
    {
        lightActivated = true;
        GetComponent<Renderer>().material = on;
        finishGate.CheckLights();
    }

    public bool IsLightActive()
    {
        return lightActivated;
    }
}
