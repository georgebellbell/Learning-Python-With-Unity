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
        Time.timeScale = 0;
    }

    public void ShowLoseUI()
    {
        LoseUI.SetActive(true);
        Time.timeScale = 0;
    }

    void RestartLevel()
    {
        Time.timeScale = 1;
        GameIsRunning(true);
        SceneManager.LoadScene(sceneIndex);
    }

    public void GameIsRunning(bool gameStatus)
    {
        gameRunning = gameStatus;
    }

    public bool IsGameRunning()
    {
        return gameRunning;
    }
}
