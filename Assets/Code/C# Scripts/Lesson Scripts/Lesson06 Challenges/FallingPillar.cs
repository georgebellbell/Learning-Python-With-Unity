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
    [SerializeField] PillarType currentPillarType = PillarType.none;
    [SerializeField] PillarType targetPlatformType = PillarType.none;

    [SerializeField] Material red, blue, purple;

    Animator animator;
    Renderer pillarRenderer;

    bool correctPillar;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        pillarRenderer = GetComponentInChildren<Renderer>();
    }

    /// <summary>
    /// Pillar is assigned the platform type of the button and correct pillar status assigned
    /// </summary>
    /// <param name="pillarType">PillarType assigned to button pressed</param>
    public void ActivatePillar(PillarType pillarType)
    {
        currentPillarType = pillarType;
        SetPlatformColour();

        correctPillar = currentPillarType == targetPlatformType;
    }

    /// <summary>
    /// Colour of pillar assigned based on pillar type
    /// </summary>
    private void SetPlatformColour()
    {
        switch (currentPillarType)
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

    /// <summary>
    /// Checks if pillar has been correctly enabled
    /// </summary>
    /// <returns>true if matching pillarType, false if not</returns>
    public bool GetPillarStatus()
    {
        return correctPillar;
    }

    /// <summary>
    /// Drops pillar through animation
    /// </summary>
    public void DropPillar()
    {
        animator.SetTrigger("Drop Platform");
    }
}
