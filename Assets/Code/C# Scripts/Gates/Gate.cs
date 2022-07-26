/*
 * 
 * Author: George Bell
 * Since:  07-07-2022
 * Organisation: Newcastle University
 * 
*/
using UnityEngine;

public class Gate : MonoBehaviour
{
    [SerializeField] public bool gateOpen;
    [SerializeField] public Material gateOpenMaterial;
    
    /// <summary>
    /// Sets gate colour to green and collider to trigger, allowing movement pass the gate
    /// </summary>
    public void OpenGate()
    {
        GetComponent<Renderer>().material = gateOpenMaterial;
        GetComponent<Collider>().isTrigger = true;
    }

    /// <summary>
    /// Upon entering the gate, function is called with functionality dependent on subclass
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        TriggerEnter();
    }

    /// <summary>
    /// virtual function to be overridden
    /// </summary>
    public virtual void TriggerEnter()
    {
      
    }
}
