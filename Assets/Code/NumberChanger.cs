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
        Debug.Log("Button be activating:)");
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
