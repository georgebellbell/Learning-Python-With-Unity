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

    /// <summary>
    /// overrides ActivateButton to run python code to rise platforms
    /// </summary>
    public override void ActivateButton()
    {
        base.ActivateButton();
        PythonRunner.RunFile($"{Application.dataPath}/code/lesson06/01.py");
    }

    /// <summary>
    /// Gets a list of all platforms
    /// </summary>
    /// <returns>Array of all rising platforms</returns>
    public RisingPlatform[] GetPlatforms()
    {
        return platforms;
    }
}
