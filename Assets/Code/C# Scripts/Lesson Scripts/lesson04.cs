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
        PythonRunner.RunFile($"{Application.dataPath}/code/lesson04.py");
        RemoveShield();
    }

    private void RemoveShield()
    {
        playerEnergyType = EnergyType.None;
        shield.SetActive(false);
    }

    private void WinGame()
    {
        levelController.EndLevel(true);
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
        StartCoroutine(DisintegratePlayerAndEndGame());
    }

    IEnumerator DisintegratePlayerAndEndGame()
    {
        animator.SetTrigger("PlayerDeath");
        yield return new WaitForSeconds(1f);
        levelController.EndLevel(false);
    }
}
