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

    /// <summary>
    /// overrides AcitvateButton to assign numbers to Gate_Number object and then runs python code
    /// </summary>
    public override void ActivateButton()
    {
        base.ActivateButton();
        gate.SetNumbers();
        PythonManager.RunOrangeRoom();
        //PythonRunner.RunFile($"{Application.dataPath}/code/lesson06/03.py");
    }
}
