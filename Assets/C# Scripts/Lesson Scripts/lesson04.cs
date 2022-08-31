/*
 * 
 * Author: George Bell
 * Since:  07-07-2022
 * Organisation: Newcastle University
 * 
*/
using UnityEngine;
using UnityEditor.Scripting.Python;
using System.Collections;

public class lesson04 : MonoBehaviour
{
    [SerializeField] GameObject shield;
    [SerializeField] EnergyType playerEnergyType;
    [SerializeField] EnergyType wallTypeHit;

    Animator animator;
    LevelController levelController;

    bool playerDead = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
        levelController = FindObjectOfType<LevelController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        string colliderTag = other.gameObject.tag;

        switch (colliderTag)
        {
            case "shield":
                ActivateShield(other.gameObject);
                break;
            case "obstacle":
                TriggerObstacle(other.gameObject);
                break;
            case "finish":
                WinGame();
                break;
        }
    }

    /// <summary>
    /// If player hits a shield object, player "gains" shield of that type and destroys that shield pickup
    /// </summary>
    /// <param name="shieldPickup">shield the player has hit </param>
    public void ActivateShield(GameObject shieldPickup)
    {
        playerEnergyType = shieldPickup.GetComponent<EnergyObject>().GetEnergyType();
        shield.GetComponent<Renderer>().material = shieldPickup.GetComponent<Renderer>().material;
        shield.SetActive(true);
        Destroy(shieldPickup);
    }

    /// <summary>
    /// If player hits a wall, the wall type is assigned, python code runs and shield is removed
    /// </summary>
    /// <param name="obstacle"></param>
    private void TriggerObstacle(GameObject obstacle)
    {
        wallTypeHit = obstacle.GetComponent<EnergyObject>().GetEnergyType();
        PythonManager.RunLevel("4");

        if (wallTypeHit != playerEnergyType && !playerDead)
        {
            Debug.LogError("Shield and Wall type do not match but player is still alive, please fix");
            return;
        }

        if (playerDead)
        {
            levelController.EndLevel(false);
        }
        RemoveShield();
    }

    /// <summary>
    /// Deactivates shield object and sets playerEnergyType to none
    /// </summary>
    private void RemoveShield()
    {
        playerEnergyType = EnergyType.None;
        shield.SetActive(false);
    }

    /// <summary>
    /// Ends level with a win
    /// </summary>
    private void WinGame()
    {
        levelController.EndLevel(true);
    }

    /// <summary>
    /// Called via Python, retrieves wall energy type hit as a string
    /// </summary>
    /// <returns>string value for EnergyType</returns>
    public string GetWallType()
    {
        switch (wallTypeHit)
        {
            case EnergyType.Red:
                return "red";
            case EnergyType.Blue:
                return "blue";
            case EnergyType.Green:
                return "green";
            case EnergyType.Purple:
                return "purple";
            default:
                return "none";
        }
    }

    /// <summary>
    /// Called via Python, retrieves player energy type hit as a string
    /// </summary>
    /// <returns>string value for EnergyType</returns>
    public string GetPlayerType()
    {
        switch (playerEnergyType)
        {
            case EnergyType.Red:
                return "red";
            case EnergyType.Blue:
                return "blue";
            case EnergyType.Green:
                return "green";
            case EnergyType.Purple:
                return "purple";
            default:
                return "none";
        }
    }

    /// <summary>
    /// Called via Python, killing player
    /// </summary>
    public void KillPlayer()
    {
        animator.SetTrigger("PlayerDeath");
        playerDead = true;
        //levelController.EndLevel(false);
    }

}
