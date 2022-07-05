using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Scripting.Python;
using System;
using TMPro;

public class lesson01And02 : MonoBehaviour
{
    [SerializeField] Platform[] platforms;
    [SerializeField] GameObject[] tasksLevels;

    [SerializeField] GameObject levelPicker;
    [SerializeField] TextMeshProUGUI startTest, timeCountUI;

    [SerializeField] int lessonNumber, timeCount;

    LevelController levelController;

    bool pythonRan = false;

    private void Start()
    {
        levelController = FindObjectOfType<LevelController>();
        timeCountUI.text = "" + timeCount;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !pythonRan)
        {
            startTest.enabled = false;
            StartCoroutine(Countdown(timeCount));
            PythonRunner.RunFile($"{Application.dataPath}/code/lesson0" + lessonNumber + ".py");
        }
    }

    private IEnumerator Countdown(int seconds)
    {
     
        int counter = seconds;
        while (counter > 0 )
        {
            yield return new WaitForSeconds(1);
            counter--;
            timeCountUI.text = "" + counter;
        }
        CheckActivePlatforms();
    }

    void CheckActivePlatforms()
    {
        platforms = FindObjectsOfType<Platform>();
        bool validLoop = false;
        foreach(Platform platform in platforms)
        {
            if (platform.GetPlatformType() != Platform.PlatformType.floor)
            {
                if (platform.GetPlatformStatus() == true)
                {
                    validLoop = true;
                }
                else
                {
                    validLoop = false;
                    break;
                }
            }
        }

        if (validLoop)
        {
            CorrectLoop();
        }
        else
        {
            FailedLoop();
        }
    }

    private void CorrectLoop()
    {
        levelController.GameIsRunning(false);
        Debug.Log("CorrectLoop!");
        levelController.ShowWinUI();
    }

    public void FailedLoop()
    {
        levelController.GameIsRunning(false);
        Debug.Log("Your for loop didnt work, please try again");
        levelController.ShowLoseUI();
    }

    public void ActivateTask(int task)
    {
        
        // deactivate UI for choosing level
        levelPicker.gameObject.SetActive(false);
        // activate level selected
        tasksLevels[task].SetActive(true);
        // activate UI for pressing space
        startTest.enabled = true;
    }

    public void CreateCube(float xPos)
    {
        GameObject newObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
        newObject.tag = "cube";
        SetPositionAndAddComponents(xPos, newObject);

    }

    public void CreateSphere(float xPos)
    {
        GameObject newObject = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        newObject.tag = "sphere";
        SetPositionAndAddComponents(xPos, newObject);
    }

    public void CreateCylinder(float xPos)
    {
        GameObject newObject = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        newObject.tag = "cylinder";
        newObject.transform.Rotate(new Vector3(90, 0, 0), Space.Self);
        SetPositionAndAddComponents(xPos, newObject);
    }

    private static void SetPositionAndAddComponents(float xPos, GameObject newObject)
    {
        Vector3 vector = new Vector3(xPos * 2.0f, xPos + 1);
        newObject.transform.position = vector;
        newObject.AddComponent<Rigidbody>().drag = 2;
    }
}
