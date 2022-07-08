/*
 * 
 * Author: George Bell
 * Since:  07-07-2022
 * Organisation: Newcastle University
 * 
*/
using UnityEngine;
using UnityEditor.Scripting.Python;

public class Button_Platforms : Button
{
    [SerializeField] RisingPlatform[] platforms = new RisingPlatform[5];

    public override void ActivateButton()
    {
        base.ActivateButton();
        PythonRunner.RunFile($"{Application.dataPath}/code/lesson06/01.py");
    }

    public RisingPlatform[] GetPlatforms()
    {
        return platforms;
    }
}
