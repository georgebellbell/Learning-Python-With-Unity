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

    /// <summary>
    /// Resumes the game and disables pause UI
    /// </summary>
    public void Resume()
    {
        StartGame();
        PauseUI.SetActive(false);
    }

    /// <summary>
    /// Restricts mouse to Screen, and enables timescale again
    /// </summary>
    public void StartGame()
    {
        if(PauseUI)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        GameIsPaused = false;
        Time.timeScale = 1;
    }

    /// <summary>
    /// Stops the game and shows the pause UI
    /// </summary>
    void Pause()
    {
        StopGame();
        PauseUI.SetActive(true);
    }

    /// <summary>
    /// Unrestricts mouse and disables timescale
    /// </summary>
    public void StopGame()
    {
        Cursor.lockState = CursorLockMode.None;
        GameIsPaused = true;
        Time.timeScale = 0;
    }

    /// <summary>
    /// Reloads the current screen
    /// </summary>
    public void Restart()
    {
        SceneManager.LoadScene(sceneIndex);
    }

    /// <summary>
    /// Loads the Main Menu scene
    /// </summary>
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    /// <summary>
    /// Assigned to buttons and loads specific level
    /// </summary>
    /// <param name="levelIndex">Scene to be loaded</param>
    public void PlayLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }
}
