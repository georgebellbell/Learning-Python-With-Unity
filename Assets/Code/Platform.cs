using System;
using System.Collections;
using System.Collections.Generic;
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

    lesson01And02 lesson01;
    [SerializeField] bool platformActivated = false;

    private void Start()
    {
        lesson01 = FindObjectOfType<lesson01And02>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        GameObject spawnedObject = collision.gameObject;
        switch(thisPlatform)
        {
            case PlatformType.cube:
                if (spawnedObject.CompareTag("cube"))
                {
                    ActivatePlatform(spawnedObject);
                }
                else
                {
                    ErrorPlatform(spawnedObject);
                }
                break;
            case PlatformType.sphere:
                if (spawnedObject.CompareTag("sphere"))
                {
                    ActivatePlatform(spawnedObject);
                }
                else
                {
                    ErrorPlatform(spawnedObject);
                }
                break;
            case PlatformType.cylinder:
                if (spawnedObject.CompareTag("cylinder"))
                {
                    ActivatePlatform(spawnedObject);
                }
                else
                {
                    ErrorPlatform(spawnedObject);
                }
                break;
            case PlatformType.floor:
                ErrorPlatform(spawnedObject);
                break;
        }
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
        lesson01.FailedLoop();
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
