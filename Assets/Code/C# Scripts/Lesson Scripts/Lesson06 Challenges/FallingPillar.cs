/*
 * 
 * Author: George Bell
 * Since:  07-07-2022
 * Organisation: Newcastle University
 * 
*/
using UnityEngine;

public class FallingPillar : MonoBehaviour
{
    Animator animator;
    Renderer pillarRenderer;

    [SerializeField]PillarType currentPlatformType = PillarType.none;
    [SerializeField] PillarType targetPlatformType = PillarType.none;

    [SerializeField] Material red, blue, purple;

    bool correctPlatform;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        pillarRenderer = GetComponentInChildren<Renderer>();
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
                pillarRenderer.material = red;
                break;
            case PillarType.blue:
                pillarRenderer.material = blue;
                break;
            case PillarType.purple:
                pillarRenderer.material = purple;
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
