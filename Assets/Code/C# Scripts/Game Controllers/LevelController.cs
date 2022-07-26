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

    bool gameRunning = true;
    int sceneIndex;

    void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    /// <summary>
    /// If R key is pressed, when the end of game is reached, the level will restart
    /// </summary>
    void Update()
    {
        if (gameRunning == false && Input.GetKeyDown(KeyCode.R))
        {
            RestartLevel();
        }
    }
    
    /// <summary>
    /// Reloads the current scene and restarts the time
    /// </summary>
    public void RestartLevel()
    {
        TogglePause();
        SceneManager.LoadScene(sceneIndex);
    }

    /// <summary>
    /// Pauses or unpauses the game
    /// </summary>
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

    /// <summary>
    /// Game ends, and depending on value passed in, game will be won or lost
    /// </summary>
    /// <param name="GameWon">true if game has been won, false if game has been lost</param>
    public void EndLevel(bool GameWon)
    {
        PauseGame();

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
    /// Stops the game entirely
    /// </summary>
    void PauseGame()
    {
        gameRunning = false;
        Time.timeScale = 0;
    }

    /// <summary>
    /// Checks if game is running or not
    /// </summary>
    /// <returns>true if game is running, false if game is not running</returns>
    public bool IsGameRunning()
    {
        return gameRunning;
    }

}
