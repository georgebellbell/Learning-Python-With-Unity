/*
 * 
 * Author: George Bell
 * Since:  07-07-2022
 * Organisation: Newcastle University
 * 
*/
using UnityEngine;
using UnityEditor.Scripting.Python;

public class Button_Number : Button
{
    [SerializeField] Gate_Number gate;

    public override void ActivateButton()
    {
        base.ActivateButton();
        gate.SetNumbers();
        PythonRunner.RunFile($"{Application.dataPath}/code/lesson06/03.py");
    }
}
