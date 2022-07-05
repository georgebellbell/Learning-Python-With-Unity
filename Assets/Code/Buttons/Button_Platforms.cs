using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Scripting.Python;

public class Button_Platforms : Button
{
    [SerializeField] RisingPlatform[] platforms = new RisingPlatform[5];

    public override void ActivateButton()
    {
        base.ActivateButton();
        Debug.Log("Platform Button");
        RunPythonCode();
    }

    private IEnumerator ActivatePlatforms()
    {
        foreach (RisingPlatform platform in platforms)
        {
            yield return new WaitForSeconds(0.66f);
            platform.ActivatePlatform();
            

        }
    }

    public RisingPlatform[] GetPlatforms()
    {
        return platforms;
    }

    public override void RunPythonCode()
    {
        PythonRunner.RunFile($"{Application.dataPath}/code/lesson06/01.py");
    }

}
