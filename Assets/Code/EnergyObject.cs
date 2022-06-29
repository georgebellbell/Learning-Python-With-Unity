using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyObject : MonoBehaviour
{
    [SerializeField] EnergyType energyType = EnergyType.None;

    [SerializeField] Material red, blue, green, purple;
    // Start is called before the first frame update
    void Start()
    {

        Renderer renderer = GetComponent<Renderer>();
        switch (energyType)
        {
            case EnergyType.Red:
                renderer.material = red;
                break;
            case EnergyType.Blue:
                renderer.material = blue;
                break;
            case EnergyType.Green:
                renderer.material = green;
                break;
            case EnergyType.Purple:
                renderer.material = purple;
                break;
        }

    }

    
    public EnergyType GetEnergyType()
    {
        return energyType;
    }


}
