using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Platforms : Button
{
    [SerializeField] RisingPlatform[] platforms = new RisingPlatform[5];

    public override void ActivateButton()
    {
        base.ActivateButton();
        Debug.Log("Platform Button");
        StartCoroutine(ActivatePlatforms());
    }

    private IEnumerator ActivatePlatforms()
    {
        foreach (RisingPlatform platform in platforms)
        {
            yield return new WaitForSeconds(0.66f);
            platform.ActivatePlatform();
            

        }
    }
}
