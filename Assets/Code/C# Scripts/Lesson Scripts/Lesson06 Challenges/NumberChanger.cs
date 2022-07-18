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

public class NumberChanger : Button
{

    public enum MathsOperator
    {
        plus,
        minus
    }
    [SerializeField] Number linkedNumber;

    [SerializeField] MathsOperator mathsOperator;

    public override void ActivateButton()
    {
        if (mathsOperator == MathsOperator.plus)
        {
            linkedNumber.IncreaseValue();
        }
        else
        {
            linkedNumber.DecreaseValue();
        }
    }

}
