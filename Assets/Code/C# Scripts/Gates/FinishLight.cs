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

    /// <summary>
    /// Activates light and checks which other lights are active
    /// </summary>
    public void ActivateLight()
    {
        lightActivated = true;
        GetComponent<Renderer>().material = on;
        finishGate.CheckLights();
    }

    /// <summary>
    /// Checks if specific light is active
    /// </summary>
    /// <returns>true if light is active, false if light is not active </returns>
    public bool IsLightActive()
    {
        return lightActivated;
    }
}
