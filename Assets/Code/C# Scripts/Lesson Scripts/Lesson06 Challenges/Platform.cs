/*
 * 
 * Author: George Bell
 * Since:  07-07-2022
 * Organisation: Newcastle University
 * 
*/
using UnityEngine;

public class Platform : MonoBehaviour
{
    public enum PlatformType
    {
        cube,
        sphere,
        cylinder,
        floor
    }

    [SerializeField] PlatformType thisPlatform;
    [SerializeField] bool platformActivated = false;

    lesson01And02 lesson;

    private void Start()
    {
        lesson = FindObjectOfType<lesson01And02>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        GameObject spawnedObject = collision.gameObject;
        string type = spawnedObject.tag;
        if(thisPlatform != PlatformType.floor)
        {
            if (thisPlatform.ToString() == type)
            {
                lesson.IncreaseTimeRemaining();
                ActivatePlatform(spawnedObject);

                return;
            }
        }
        ErrorPlatform(spawnedObject);
    }

    private void ActivatePlatform(GameObject spawnedObject)
    {
        GetComponent<Renderer>().material.color = Color.green;
        spawnedObject.gameObject.GetComponent<Renderer>().material.color = Color.green;

        platformActivated = true;
    }

    private void ErrorPlatform(GameObject spawnedObject)
    {
        GetComponent<Renderer>().material.color = Color.red;
        spawnedObject.gameObject.GetComponent<Renderer>().material.color = Color.red;
        lesson.FailedLoop();
    }

    public bool GetPlatformStatus()
    {
        return platformActivated;
    }

    public PlatformType GetPlatformType()
    {
        return thisPlatform;
    }
}
