using System;
using System.Collections;
using System.Collections.Generic;
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
        //Debug.Log(other.gameObject.tag);
        
        TriggerEnter();
      
    }

    public virtual void TriggerEnter()
    {
        Debug.Log("cheese");
    }
}
