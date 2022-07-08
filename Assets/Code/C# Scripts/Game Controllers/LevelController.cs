/*
 * 
 * Author: George Bell
 * Since:  07-07-2022
 * Organisation: Newcastle University
 * 
*/
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject WinUI, LoseUI;

    private bool gameRunning = true;
    int sceneIndex;

    void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    void Update()
    {
        if (gameRunning == false && Input.GetKeyDown(KeyCode.T))
        {
            RestartLevel();
        }
    }

    void RestartLevel()
    {
        TogglePause();
        SceneManager.LoadScene(sceneIndex);
    }

    public void TogglePause()
    {
        gameRunning = !gameRunning;

        if (gameRunning)
        {
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
        }
    }

    public void EndLevel(bool GameWon)
    {
        TogglePause();

        if (GameWon)
        {
            ShowWinUI();
        }
        else
        {
            ShowLoseUI();
        }
    }

    private void ShowWinUI()
    {
        WinUI.SetActive(true);
    }

    private void ShowLoseUI()
    {
        LoseUI.SetActive(true);
    }

    public bool IsGamePaused()
    {
        return gameRunning;
    }

}
