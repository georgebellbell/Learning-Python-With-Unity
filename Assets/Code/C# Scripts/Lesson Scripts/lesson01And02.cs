/*
 * 
 * Author: George Bell
 * Since:  12-07-2022
 * Organisation: Newcastle University
 * 
*/
using System.Collections;
using UnityEngine;
using UnityEditor.Scripting.Python;
using TMPro;

public class lesson01And02 : MonoBehaviour
{
    [SerializeField] Platform[] platforms;
    //[SerializeField] GameObject[] tasksLevels;
    //[SerializeField] GameObject levelPicker;
    [SerializeField] TextMeshProUGUI startTest;
    [SerializeField] int lessonNumber;
    [SerializeField] float timeCount = 1, timeDelay = 0.5f;

    LevelController levelController;

    bool pythonRan = false;

    private void Start()
    {
        levelController = FindObjectOfType<LevelController>();
    }

    /// <summary>
    /// Waits for user to press space before starting timer and running python code
    /// </summary>
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !pythonRan)
        {
            pythonRan = true;
            startTest.enabled = false;
            StartCoroutine(Countdown());
            PythonRunner.RunFile($"{Application.dataPath}/code/lesson0" + lessonNumber + ".py");
        }
    }

    /// <summary>
    /// Timer that waits a set amount of time before checking which platforms are active
    /// </summary>
    /// <returns></returns>
    public IEnumerator Countdown()
    {
        while (timeCount > 0)
        {
            yield return new WaitForSeconds(1);
            timeCount--;
        }
       
        CheckActivePlatforms();
    }

    /// <summary>
    /// Finds all platforms in the level, checking (other than the floor) if they have been activated
    /// If all are correctly active, the loop is correct. Otherwise the loop is incorrect
    /// </summary>
    void CheckActivePlatforms()
    {
        platforms = FindObjectsOfType<Platform>();
        bool validLoop = false;

        foreach (Platform platform in platforms)
        {
            if (platform.GetPlatformType() != PlatformType.floor)
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

        levelController.EndLevel(validLoop);
    }

    /// <summary>
    /// Called by a platform object when an incorrect object hits it, ending the level with a failure
    /// </summary>
    public void FailedLoop()
    {
        levelController.EndLevel(false);
    }

    /// <summary>
    /// Assigned to a button to activate certain tasks within the level
    /// </summary>
    /// <param name="task">The specific task that will be activated</param>
    public void ActivateTask(int task)
    {
        //levelPicker.gameObject.SetActive(false);
        //tasksLevels[task].SetActive(true);
        startTest.enabled = true;
    }

    /// <summary>
    /// Called when a correct object hits a platform, increasing the remaining time
    /// </summary>
    public void IncreaseTimeRemaining()
    {
        timeCount = timeCount + timeDelay;
    }
    
    /// <summary>
    /// Creates cube for lesson 01
    /// </summary>
    /// <param name="xPos">x position of the cube</param>
    /// <param name="zPos">z position of the cube</param>
    public void CreateCube(float xPos, float zPos)
    {
        GameObject newObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
        newObject.tag = "cube";
        SetPositionAndAddComponents(xPos, zPos, newObject);
    }

    /// <summary>
    /// Creates sphere for lesson 01
    /// </summary>
    /// <param name="xPos">x position of the sphere</param>
    /// <param name="zPos">z position of the sphere</param>
    public void CreateSphere(float xPos, float zPos)
    {
        GameObject newObject = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        newObject.tag = "sphere";
        SetPositionAndAddComponents(xPos, zPos, newObject);
    } 

    /// <summary>
    /// For the new object created, assign the position and attach a rigidbody
    /// </summary>
    /// <param name="xPos">x position of the object</param>
    /// <param name="zPos">z position of the object</param>
    /// <param name="newObject">the new object that was created</param>
    private static void SetPositionAndAddComponents(float xPos, float zPos, GameObject newObject)
    {
        newObject.transform.position = new Vector3(xPos * 2.0f, xPos + 1, zPos * 2.0f); ;
        newObject.AddComponent<Rigidbody>().drag = 2;
    }

    /// <summary>
    /// Creates cube for lesson 02
    /// </summary>
    /// <param name="xPos">x position of the cube</param>
    public void CreateCube(float xPos)
    {
        GameObject newObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
        newObject.tag = "cube";
        SetPositionAndAddComponents(xPos, newObject);
    }

    /// <summary>
    /// Creates sphere for lesson 02
    /// </summary>
    /// <param name="xPos">x position of the sphere</param>
    public void CreateSphere(float xPos)
    {
        GameObject newObject = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        newObject.tag = "sphere";
        SetPositionAndAddComponents(xPos, newObject);
    }

    /// <summary>
    /// Creates cylinder for lesson 02
    /// </summary>
    /// <param name="xPos">x position of the cylinder</param>
    public void CreateCylinder(float xPos)
    {
        GameObject newObject = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        newObject.tag = "cylinder";
        newObject.transform.Rotate(new Vector3(90, 0, 0), Space.Self);
        SetPositionAndAddComponents(xPos, newObject);
    }

    /// <summary>
    /// For the new object created, assign the position and attach a rigidbody
    /// </summary>
    /// <param name="xPos">x position of the object</param>
    /// <param name="newObject">the new object that was created</param>
    private static void SetPositionAndAddComponents(float xPos, GameObject newObject)
    {
        newObject.transform.position = new Vector3(xPos * 2.0f, xPos + 1);
        newObject.AddComponent<Rigidbody>().drag = 2;
    }
}
