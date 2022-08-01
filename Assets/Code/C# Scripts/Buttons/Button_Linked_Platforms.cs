using UnityEditor.Scripting.Python;
using UnityEngine;

public class Button_Linked_Platforms : Button
{
    [SerializeField] GameObject[] platforms;
    [SerializeField] Vector3[] targetTransforms;

    public GameObject[] GetPlatformObjects()
    {
        return platforms;
    }

    public Vector3[] GetPlatformTransforms()
    {
        return targetTransforms;
    }

    public void AddPlatform(GameObject platformObject, Vector3 platformPosition)
    {
        platformObject.transform.position = platformPosition;

    }


    public override void ActivateButton()
    {
        base.ActivateButton();
        PythonRunner.RunFile($"{Application.dataPath}/code/lesson06/05.py");
    }
}
