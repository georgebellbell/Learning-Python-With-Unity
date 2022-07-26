/*
 * 
 * Author: George Bell
 * Since:  07-07-2022
 * Organisation: Newcastle University
 * 
*/
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

    /// <summary>
    /// Depending on MathsOperator type, button press overridden to change number value
    /// MathsOperator = plus, increase
    /// MathsOperator = minus, decrease
    /// </summary>
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
