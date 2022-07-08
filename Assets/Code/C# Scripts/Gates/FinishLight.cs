/*
 * 
 * Author: George Bell
 * Since:  07-07-2022
 * Organisation: Newcastle University
 * 
*/
using UnityEngine;

public class FinishLight : MonoBehaviour
{
    [SerializeField] Material on;

    bool lightActivated = false;
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
