using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLight : MonoBehaviour
{
    bool lightActivated = false;

    [SerializeField] Material on, off;

    FinishGate finishGate;
    private void Start()
    {
        finishGate = FindObjectOfType<FinishGate>();
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
