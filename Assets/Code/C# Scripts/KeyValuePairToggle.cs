using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Scripting.Python;
using UnityEngine;

public class KeyValuePairToggle : Button
{
    [SerializeField] KeyValuePair linkedPair;
    [SerializeField] Toggle toggleType;

    public enum Toggle
    {
        right,
        left
    }
    /// <summary>
    /// Override ActivateButton so that toggling between values and python code runs to set keys
    /// </summary>
    public override void ActivateButton()
    {
        linkedPair.SetColour(Color.white);
        if (toggleType == Toggle.right)
        {
            ToggleRight();
        }
        else if(toggleType == Toggle.left)
        {
            ToggleLeft();
        }
        PythonRunner.RunFile($"{Application.dataPath}/code/lesson06/06.py");

    }

    /// <summary>
    /// Move right through value options
    /// </summary>
    private void ToggleRight()
    {
        KeyValuePairType type = linkedPair.GetKeyValueType();

        if (type == KeyValuePairType.shape || type == KeyValuePairType.none)
        {
            linkedPair.SetToNumber();
        }
        else if (type == KeyValuePairType.number)
        {
            linkedPair.SetToLetter();
        }
        else if (type == KeyValuePairType.letter)
        {
            linkedPair.SetToShape();
        }
    }

    /// <summary>
    /// Move left through value options
    /// </summary>
    private void ToggleLeft()
    {
        KeyValuePairType type = linkedPair.GetKeyValueType();

        if (type == KeyValuePairType.shape || type == KeyValuePairType.none)
        {
            linkedPair.SetToLetter();
        }
        else if (type == KeyValuePairType.number)
        {
            linkedPair.SetToShape();
        }
        else if (type == KeyValuePairType.letter)
        {
            linkedPair.SetToNumber();
        }
    }
}
