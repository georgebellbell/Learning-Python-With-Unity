using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Scripting.Python;

public class Button_Number : Button
{
    [SerializeField] Gate_Number gate;

    public override void ActivateButton()
    {
        base.ActivateButton();
        gate.SetNumbers();
        RunPythonCode();
    }

    public override void RunPythonCode()
    {
        PythonRunner.RunFile($"{Application.dataPath}/code/lesson06/03.py");
    }
}
