using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Scripting.Python;

public class lesson04 : MonoBehaviour
{
    //bool shieldActive = false;
    [SerializeField] GameObject shield;
    [SerializeField] EnergyType playerEnergyType;

    [SerializeField] EnergyType wallTypeHit;

    Animator animator;

    LevelController levelController;

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

    

    public void ActivateShield(GameObject shieldPickup)
    {
        playerEnergyType = shieldPickup.GetComponent<EnergyObject>().GetEnergyType();
        shield.GetComponent<Renderer>().material = shieldPickup.GetComponent<Renderer>().material;
        shield.SetActive(true);
        Destroy(shieldPickup);
    }

    private void TriggerObstacle(GameObject obstacle)
    {
        wallTypeHit = obstacle.GetComponent<EnergyObject>().GetEnergyType();
        PythonCode();
        RemoveShield();
    }

    private void RemoveShield()
    {
        playerEnergyType = EnergyType.None;
        shield.SetActive(false);
    }

    private void PythonCode()
    {
        PythonRunner.RunFile($"{Application.dataPath}/code/lesson04.py");
    }

    private void WinGame()
    {
        levelController.GameIsRunning(false);
        levelController.ShowWinUI();
    }

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

    public void KillPlayer()
    {
        animator.SetTrigger("PlayerDeath");
        GetComponent<CubeController>().PlayerDied();
        levelController.ShowLoseUI();
    }



}
