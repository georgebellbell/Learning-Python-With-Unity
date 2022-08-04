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
    [SerializeField] GameObject WinUI, LoseUI, PauseUI;

    public static bool GameIsPaused = false;
    int sceneIndex;

    void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        StartGame();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && PauseUI && !(WinUI.activeSelf || LoseUI.activeSelf))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    /// <summary>
    /// Game ends, and depending on value passed in, game will be won or lost
    /// </summary>
    /// <param name="GameWon">true if game has been won, false if game has been lost</param>
    public void EndLevel(bool GameWon)
    {
        StopGame();

        if (GameWon)
        {
            WinUI.SetActive(true);
        }
        else
        {
            LoseUI.SetActive(true);
        }
    }

    public void Resume()
    {
        StartGame();
        PauseUI.SetActive(false);
    }

    public void StartGame()
    {
        if(PauseUI)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        GameIsPaused = false;
        Time.timeScale = 1;
    }

    void Pause()
    {
        StopGame();
        PauseUI.SetActive(true);
    }

    public void StopGame()
    {
        Cursor.lockState = CursorLockMode.None;
        GameIsPaused = true;
        Time.timeScale = 0;
    }

    public void Restart()
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void PlayLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }
}
