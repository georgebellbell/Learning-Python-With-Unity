using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Scripting.Python;
using TMPro;

public class lesson02 : MonoBehaviour
{
    [SerializeField] GameObject[] allCubes;
    [SerializeField] GameObject[] allSpheres;
    [SerializeField] GameObject[] allCylinders;
    [SerializeField] GameObject[] allCapsules;

    [SerializeField] TextMeshProUGUI task1;
    [SerializeField] TextMeshProUGUI task2;
    [SerializeField] TextMeshProUGUI task3;

    bool pythonRan = false;
    bool task1Complete, task2Complete, task3Complete = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !pythonRan)
        {
            pythonRan = true;
            PythonRunner.RunFile($"{Application.dataPath}/code/lesson02.py");
        }

        FindObjects();
        DetermineTasksCompleted();
    }
    private void FindObjects()
    {
        allCubes = GameObject.FindGameObjectsWithTag("cube");
        allSpheres = GameObject.FindGameObjectsWithTag("sphere");
        allCylinders = GameObject.FindGameObjectsWithTag("cylinder");
        allCapsules = GameObject.FindGameObjectsWithTag("capsule");
    }

    private void DetermineTasksCompleted()
    {
        task1Complete = allCubes.Length == 2 && allSpheres.Length == 1 && allCylinders.Length == 0 && allCapsules.Length == 0;
        task2Complete = allCubes.Length == 0 && allSpheres.Length == 0 && allCylinders.Length == 0 && allCapsules.Length == 1;
        task3Complete = allCubes.Length == 0 && allSpheres.Length == 0 && allCylinders.Length == 5 && allCapsules.Length == 0;

        if (task1Complete)
        {
            task1.color = Color.green;
            task2.color = Color.red;
            task3.color = Color.red;
        }
        else if (task2Complete)
        {
            task1.color = Color.red;
            task2.color = Color.green;
            task3.color = Color.red;
        }
        else if (task3Complete)
        {
            task1.color = Color.red;
            task2.color = Color.red;
            task3.color = Color.green;
        }
        else
        {
            task1.color = Color.red;
            task2.color = Color.red;
            task3.color = Color.red;
        }
    }
}
