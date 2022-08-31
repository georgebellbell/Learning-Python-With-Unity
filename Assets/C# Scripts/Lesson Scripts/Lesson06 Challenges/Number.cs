/*
 * 
 * Author: George Bell
 * Since:  07-07-2022
 * Organisation: Newcastle University
 * 
*/
using UnityEngine;

public class Number : MonoBehaviour
{
    [SerializeField] int numberValue;
    [SerializeField] Mesh[] numbers;

    /// <summary>
    /// Increase value of wall number by one
    /// </summary>
    public void IncreaseValue()
    {
        numberValue++;

        if (numberValue > 9)
        {
            numberValue = 0;
        }

        UpdateMesh();
    }

    /// <summary>
    /// Decrease value of wall number by one
    /// </summary>
    public void DecreaseValue()
    {
        numberValue--;

        if (numberValue < 0 || numberValue > 9)
        {
            numberValue = 9;
        }

        UpdateMesh();
    }

    /// <summary>
    /// Change wall number mesh to represent new number value
    /// </summary>
    void UpdateMesh()
    {
        if (numberValue >= 0 && numberValue <= 9)
            GetComponent<MeshFilter>().mesh = numbers[numberValue];
    }

    /// <summary>
    /// Gets current wall number value
    /// </summary>
    /// <returns>integer for wall number</returns>
    public int GetValue()
    {
        return numberValue;
    }
}
