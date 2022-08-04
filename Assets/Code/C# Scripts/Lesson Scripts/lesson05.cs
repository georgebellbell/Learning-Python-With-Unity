/*
 * 
 * Author: George Bell
 * Since:  11-07-2022
 * Organisation: Newcastle University
 * 
*/
using UnityEngine;
using UnityEditor.Scripting.Python;
using TMPro;
using System.Collections;

public class lesson05 : MonoBehaviour
{
    [SerializeField] float targetCubeNumber, cubesHit;
    [SerializeField] TextMeshProUGUI cubeCountUI;
    [SerializeField] GameObject spaceObject;

    LevelController levelController;
    Renderer platformRenderer;
    Color lerpedColour = Color.white;
    bool pythonRan = false;

    void Start()
    {
        levelController = FindObjectOfType<LevelController>();
        platformRenderer = GetComponent<Renderer>();
        PlatformUpdate();
    }

    /// <summary>
    /// If space key is pressed, and python code hasn't ran before, python code runs
    /// </summary>
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !pythonRan)
        {
            spaceObject.SetActive(false);
            pythonRan = true;
            PythonRunner.RunFile($"{Application.dataPath}/code/lesson05.py");
            StartCoroutine(Countdown());
        }    
    }

    /// <summary>
    /// Creates cubes at different y positions
    /// </summary>
    /// <param name="yPos">float, y position of the cube</param>
    public void CreateCube(float yPos)
    {
        GameObject newObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
        newObject.transform.position = new Vector3(0, (yPos + 1) * 5, 0);
        newObject.AddComponent<Rigidbody>().drag = 2;
        newObject.tag = "cube";
    }

    /// <summary>
    /// As Python code is ran, timer starts and after set time, object count is checked
    /// </summary>
    /// <returns></returns>
    public IEnumerator Countdown()
    {
        int timeToCheck = 7;

        while (timeToCheck > 0)
        {
            yield return new WaitForSeconds(1);
            timeToCheck--;
        }

        CheckCubes();
    }

    /// <summary>
    /// If the number of cubes collected is correct and there are no more instances in the scene, the level ends in a win
    /// Otherwise, the level ends in a fail
    /// </summary>
    private void CheckCubes()
    {
        if (cubesHit == targetCubeNumber && !GameObject.FindGameObjectWithTag("cube"))
        {
            levelController.EndLevel(true);
        }
        else
        {
            levelController.EndLevel(false);
        }
    }

    /// <summary>
    /// When cube hits platform, cube hit count increases, the cube is destroyed and scene is updated
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        cubesHit++;
        Destroy(collision.gameObject);
        PlatformUpdate();   
    }

    /// <summary>
    /// With every cube that hits platform, cube count UI increases and colour gradually changes towards green
    /// Unless too many cubes hit then it instantly turns red and game ends
    /// </summary>
    private void PlatformUpdate()
    {
        if (cubesHit == 0)
        {
            lerpedColour = Color.white;
        }
        else if (cubesHit <= targetCubeNumber)
        {
            float percent = cubesHit / targetCubeNumber;
            lerpedColour = Color.Lerp(Color.white, Color.green, percent);
        }
        else
        {
            lerpedColour = Color.red;
            levelController.EndLevel(false);
        }
        platformRenderer.material.color = lerpedColour;

        cubeCountUI.text = cubesHit + " / " + targetCubeNumber;
        cubeCountUI.color = lerpedColour;

    }
}
