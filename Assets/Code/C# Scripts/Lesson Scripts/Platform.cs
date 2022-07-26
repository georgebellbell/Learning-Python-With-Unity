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
    [SerializeField] PlatformType thisPlatform;
    bool platformActivated = false;

    lesson01And02 lesson;

    private void Start()
    {
        lesson = FindObjectOfType<lesson01And02>();
    }

    /// <summary>
    /// When object hits platform, tag on object is checked
    /// If it matches platform type, platform will activate successfully
    /// Otherwise, the platform will fail and the level will end
    /// </summary>
    /// <param name="collision">Falling object created via python</param>
    private void OnCollisionEnter(Collision collision)
    {
        GameObject spawnedObject = collision.gameObject;
        
        if (thisPlatform.ToString() == spawnedObject.tag)
        {
            lesson.IncreaseTimeRemaining();
            ActivatePlatform(spawnedObject);
            return;
        }
        ErrorPlatform(spawnedObject);
    }

    /// <summary>
    /// If platform and object match, both will change colour to green and platform will be set to true
    /// </summary>
    /// <param name="spawnedObject">Python object that hit the platform</param>
    private void ActivatePlatform(GameObject spawnedObject)
    {
        GetComponent<Renderer>().material.color = Color.green;
        spawnedObject.gameObject.GetComponent<Renderer>().material.color = Color.green;

        platformActivated = true;
    }

    /// <summary>
    /// If platform and object do not match, both will change colour to red and lesson will end
    /// </summary>
    /// <param name="spawnedObject"></param>
    private void ErrorPlatform(GameObject spawnedObject)
    {
        GetComponent<Renderer>().material.color = Color.red;
        spawnedObject.gameObject.GetComponent<Renderer>().material.color = Color.red;
        lesson.FailedLoop();
    }

    /// <summary>
    /// Retrieves the current status of the platform
    /// </summary>
    /// <returns>true if platform has been activated, false if platform has not been activated</returns>
    public bool GetPlatformStatus()
    {
        return platformActivated;
    }

    /// <summary>
    /// Returns the current platform type
    /// </summary>
    /// <returns>the current platform type</returns>
    public PlatformType GetPlatformType()
    {
        return thisPlatform;
    }
}
