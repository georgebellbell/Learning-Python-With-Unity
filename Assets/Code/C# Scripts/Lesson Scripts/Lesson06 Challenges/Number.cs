/*
 * 
 * Author: George Bell
 * Since:  07-07-2022
 * Organisation: Newcastle University
 * 
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Number : MonoBehaviour
{
    [SerializeField] int numberValue = 0;

    Mesh mesh;

    [SerializeField] Mesh[] numbers;

    public void IncreaseValue()
    {
        numberValue++;

        if (numberValue > 9)
        {
            numberValue = 0;
        }

        UpdateMesh();

    }

    public void DecreaseValue()
    {
        numberValue--;

        if (numberValue < 0)
        {
            numberValue = 9;
        }

        UpdateMesh();

    }

    void UpdateMesh()
    {
        if (numberValue >= 0 && numberValue <= 9)
        GetComponent<MeshFilter>().mesh = numbers[numberValue];
    }

    public int GetValue()
    {
        return numberValue;
    }
}
