/*
 * 
 * Author: George Bell
 * Since:  07-07-2022
 * Organisation: Newcastle University
 * 
*/
using UnityEngine;

public class EnergyObject : MonoBehaviour
{
    [SerializeField] EnergyType energyType = EnergyType.None;
    [SerializeField] Material red, blue, green, purple;

    /// <summary>
    /// At start of level, both the shields and walls have their colours assigned to them
    /// </summary>
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
    
    /// <summary>
    /// Get the energy type of current object
    /// </summary>
    /// <returns></returns>
    public EnergyType GetEnergyType()
    {
        return energyType;
    }
}
