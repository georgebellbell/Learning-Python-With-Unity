/*
 * 
 * Author: George Bell
 * Since:  07-07-2022
 * Organisation: Newcastle University
 * 
*/
using UnityEngine;

public class Gate_Number : Gate
{
    [Tooltip("All numbers stored")]
    [SerializeField] int[] numbers = new int[6];

    [Header("Equation A")]
    [SerializeField] Number num1Object;
    [SerializeField] int number1;
    [SerializeField] Number num2Object;
    [SerializeField] int number2;
    [SerializeField] Number num3Object;
    [SerializeField] int number3;

    [Header("Equation B")]
    [SerializeField] Number num4Object;
    [SerializeField] int number4;
    [SerializeField] Number num5Object;
    [SerializeField] int number5;
    [SerializeField] Number num6Object;
    [SerializeField] int number6;
    
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
}
