using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPillar : MonoBehaviour
{
    Animator animator;
    Renderer renderer;

    [SerializeField]PillarType currentPlatformType = PillarType.none;
    [SerializeField] PillarType targetPlatformType = PillarType.none;

    [SerializeField] Material red, blue, purple;

    bool correctPlatform;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        renderer = GetComponentInChildren<Renderer>();
    }

    public void ActivatePillar(PillarType platformType)
    {
        currentPlatformType = platformType;
        SetPlatformColour();

        correctPlatform = currentPlatformType == targetPlatformType;
        

    }

    private void SetPlatformColour()
    {
        switch (currentPlatformType)
        {
            case PillarType.red:
                renderer.material = red;
                break;
            case PillarType.blue:
                renderer.material = blue;
                break;
            case PillarType.purple:
                renderer.material = purple;
                break;

        }
    }

    public bool GetPillarStatus()
    {
        return correctPlatform;
    }

    public void DropPillar()
    {
        animator.SetTrigger("Drop Platform");
    }
}
