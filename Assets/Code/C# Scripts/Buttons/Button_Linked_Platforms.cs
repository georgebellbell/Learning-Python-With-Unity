using UnityEditor.Scripting.Python;
using UnityEngine;

public class Button_Linked_Platforms : Button
{
    [SerializeField] GameObject[] platforms;
    [SerializeField] Vector3[] targetTransforms;

    /// <summary>
    /// Called via python to retrieve all platform objects as a list
    /// </summary>
    /// <returns></returns>
    public GameObject[] GetPlatformObjects()
    {
        return platforms;
    }

    /// <summary>
    /// Called via python to retrieve all desired platform position as a list
    /// </summary>
    /// <returns></returns>
    public Vector3[] GetPlatformTransforms()
    {
        return targetTransforms;
    }

    /// <summary>
    /// Called via python to set position of a platform to a specific position
    /// </summary>
    /// <param name="platformObject">The platform having its position set</param>
    /// <param name="platformPosition">The position the platform is being set to</param>
    public void AddPlatform(GameObject platformObject, Vector3 platformPosition)
    {
        platformObject.transform.position = platformPosition;

    }

    /// <summary>
    /// Called via python code to set run python code to create dictionary and test result by setting platform position 
    /// </summary>
    public override void ActivateButton()
    {
        base.ActivateButton();
        PythonRunner.RunFile($"{Application.dataPath}/code/lesson06/05.py");
    }
}
