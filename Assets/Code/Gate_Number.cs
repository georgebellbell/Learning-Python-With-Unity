using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate_Number : Gate
{
    [Tooltip("All numbers stored")]
    [SerializeField] int[] numbers = new int[6];

    [Header("Equation A")]
    [SerializeField] int number1; 
    [SerializeField] int number2;
    [SerializeField] int number3;
    [SerializeField] Number num1Object;
    [SerializeField] Number num2Object;
    [SerializeField] Number num3Object;

    [Header("Equation B")]
    [SerializeField] int number4;
    [SerializeField] int number5;
    [SerializeField] int number6;
    [SerializeField] Number num4Object;
    [SerializeField] Number num5Object;
    [SerializeField] Number num6Object;



    public void SetNumbers()
    {
        number1 = num1Object.GetValue();
        number2 = num2Object.GetValue();
        number3 = num3Object.GetValue();

        number4 = num4Object.GetValue();
        number5 = num5Object.GetValue();
        number6 = num6Object.GetValue();

        numbers = new int[6] { number1, number2, number3, number4, number5, number6};
    }
    

    public void CheckGate()
    {
        // unity side checking to see if numbers are valid
        bool equationA = number1 < number2 && number2 < number3;
        bool equationB = number4 * number5 == number6;

        gateOpen = equationA && equationB;

        if (gateOpen)
        {
            OpenGate();
        }
    }

    public int[] GetNumbers()
    {
        return numbers;
    }

    public override void TriggerEnter()
    {
        base.TriggerEnter();
        Debug.Log("Number Gate!");
    }
}
