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
    
    public void OpenGate()
    {
        GetComponent<Renderer>().material = gateOpenMaterial;
        GetComponent<Collider>().isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        TriggerEnter();
    }

    public virtual void TriggerEnter()
    {
      
    }
}
