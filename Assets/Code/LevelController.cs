using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class LevelController : MonoBehaviour
{
    private bool gameRunning = true;
    int sceneIndex;

    [SerializeField] GameObject WinUI, LoseUI;
    // Start is called before the first frame update
    void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameRunning == false && Input.GetKeyDown(KeyCode.T))
        {
            RestartLevel();
        }
    }

    public void ShowWinUI()
    {
        WinUI.SetActive(true);
    }

    public void ShowLoseUI()
    {
        LoseUI.SetActive(true);
    }

    void RestartLevel()
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void SetGameStatus(bool gameStatus)
    {
        gameRunning = gameStatus;
    }

    public bool GetGameStatus()
    {
        return gameRunning;
    }
}
