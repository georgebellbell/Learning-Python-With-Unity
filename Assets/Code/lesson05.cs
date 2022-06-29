using UnityEngine;
using UnityEditor.Scripting.Python;
using TMPro;

public class lesson05 : MonoBehaviour
{
    [SerializeField] float targetCubeNumber, pythonCubeNumber, cubesHit;
    float currentCubeNumber;
    [SerializeField] TextMeshProUGUI cubeCountUI;
    Renderer platformRenderer;
    Color lerpedColour = Color.white;

    LevelController levelController;
    // Start is called before the first frame update
    void Start()
    {
        platformRenderer = GetComponent<Renderer>();
        levelController = FindObjectOfType<LevelController>();
        PlatformUpdate();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PythonCode();
        }
    }

    

    public void CreateCube(float yPos)
    {
        GameObject newObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
        newObject.transform.position = new Vector3(0, (yPos + 1) * 5, 0);
        newObject.AddComponent<Rigidbody>().drag = 2;  
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
        }
        platformRenderer.material.color = lerpedColour;

        cubeCountUI.text = cubesHit + " / " + targetCubeNumber;
        cubeCountUI.color = lerpedColour;

    }

    void PythonCode()
    {
        PythonRunner.RunFile($"{Application.dataPath}/code/lesson05.py");
    }
}
