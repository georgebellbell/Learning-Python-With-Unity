using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Scripting.Python;
using System;
using TMPro;

public class lesson01 : MonoBehaviour
{
    [SerializeField] ParticleSystem confettiPS;
    [SerializeField] Platform[] platforms;
    [SerializeField] GameObject[] tasksLevels;

    [SerializeField] GameObject levelPicker;
    [SerializeField] TextMeshProUGUI startTest;

    private void Start()
    {
        platforms = FindObjectsOfType<Platform>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            startTest.enabled = false;
            StartCoroutine(Countdown(5));
            PythonRunner.RunFile($"{Application.dataPath}/code/lesson01.py");
        }
    }

    private IEnumerator Countdown(int seconds)
    {
        // ADD UI OUTPUT
        int counter = seconds;
        while (counter > 0)
        {
            yield return new WaitForSeconds(1);
            counter--;
        }
        CheckActivePlatforms();
    }

    void CheckActivePlatforms()
    {
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
        Debug.Log("CorrectLoop!");
        // ADD UI OUTPUT
    }

    public void FailedLoop()
    {
        Debug.Log("Your for loop didnt work, please try again");
        // ADD UI OUTPUT
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
}
