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

    LevelController levelController;
    Renderer platformRenderer;
    Color lerpedColour = Color.white;
    float timeTaken;
    bool pythonRan = false;

    void Start()
    {
        levelController = FindObjectOfType<LevelController>();
        platformRenderer = GetComponent<Renderer>();
        PlatformUpdate();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !pythonRan)
        {
            pythonRan = true;
            PythonRunner.RunFile($"{Application.dataPath}/code/lesson05.py");
            StartCoroutine(Countdown());
        }
        
        timeTaken += Time.deltaTime;
        

    }

    

    public void CreateCube(float yPos)
    {
        GameObject newObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
        newObject.transform.position = new Vector3(0, (yPos + 1) * 5, 0);
        newObject.AddComponent<Rigidbody>().drag = 2;
        newObject.tag = "cube";
    }

    public IEnumerator Countdown()
    {
        int timeToCheck = 7;

        while (timeToCheck > 0)
        {
            yield return new WaitForSeconds(1);
            timeToCheck--;
        }
        
        if (cubesHit == targetCubeNumber && !GameObject.FindGameObjectWithTag("cube"))
        {
            levelController.EndLevel(true);
        }
        else
        {
            levelController.EndLevel(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        DestroyCube(collision.gameObject);
        
    }

    void DestroyCube(GameObject collisionObject)
    {
        cubesHit++;
        Destroy(collisionObject);
        PlatformUpdate();
    }

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
