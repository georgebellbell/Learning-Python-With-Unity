/*
 * 
 * Author: George Bell
 * Since:  07-07-2022
 * Organisation: Newcastle University
 * 
*/
using UnityEditor.Scripting.Python;
using UnityEngine;
using TMPro;

public class lesson03 : MonoBehaviour
{
    [Header("Coin Details")]
    [SerializeField] TextMeshProUGUI coinCounter;
    [SerializeField] int currentCoinCount = 0;
    [SerializeField] int totalCoinCount;

    [Header("Finish Details")]
    [SerializeField] Material finishOpen;
    [SerializeField] Material finishClosed;
    [SerializeField] GameObject finishObject;

    [Header("Task Details")]
    [SerializeField] TextMeshProUGUI[] tasksUI = new TextMeshProUGUI[7];
    [SerializeField] bool[] tasks = new bool[7];

    LevelController levelController;
    Renderer finishRenderer;
    Collider finishCollider;

    bool winnable = false;

    private void Start()
    {
        levelController = FindObjectOfType<LevelController>();
        finishRenderer = finishObject.GetComponent<Renderer>();
        finishCollider = finishObject.GetComponent<Collider>();

        totalCoinCount = GameObject.FindGameObjectsWithTag("coin").Length;
        UpdateCoinCounter();

        SetFinish(false);
        
        PythonRunner.RunFile($"{Application.dataPath}/code/lesson03.py");
        CheckTasks();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            levelController.RestartLevel();
        }
    }

    /// <summary>
    /// Ends game with a win if player enters finish gate
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("finish"))
        {
            levelController.EndLevel(true);
        }
    }

    /// <summary>
    /// If player interacts with a coin, coin count increases, object is destroyed and python code runs again
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("coin"))
        {
            Destroy(collision.gameObject);
            currentCoinCount += 1;
            UpdateCoinCounter();
            
            PythonRunner.RunFile($"{Application.dataPath}/code/lesson03.py");
            CheckTasks();
        }
    }

    /// <summary>
    /// Updates UI for coin count
    /// </summary>
    void UpdateCoinCounter()
    {
        coinCounter.text = "Coins: " + currentCoinCount + "/" + totalCoinCount;
    }

    /// <summary>
    /// Checks all the statements and if correct will highlight them green
    /// </summary>
    void CheckTasks()
    {
        // All coins
        tasks[0] = winnable && currentCoinCount == totalCoinCount;
        // No coins
        tasks[1] = winnable && currentCoinCount == 0;
        // More than three coins
        tasks[2] = winnable && currentCoinCount > 3;
        // Less than, or, five coins
        tasks[3] = winnable && currentCoinCount <= 5;
        // Between four and seven coins
        tasks[4] = winnable && currentCoinCount > 4 && currentCoinCount < 7;
        // One or six coins
        tasks[5] = winnable && (currentCoinCount == 1 || currentCoinCount == 6);
        // Not two coins
        tasks[6] = winnable && currentCoinCount != 2;

        for (int i = 0; i < tasksUI.Length; i++)
        {
            if (tasks[i])
            {
                tasksUI[i].color = Color.green;
            }
            else
            {
                tasksUI[i].color = Color.red;
            }
        }
    }

    /// <summary>
    /// Retrieves the current number of coins collected
    /// </summary>
    /// <returns> integer, number of coins</returns>
    public int GetCoinCount()
    {
        return currentCoinCount;
    }

    /// <summary>
    /// Called via python script, opening gate if correctCoinAmount is true, and vice versa is false
    /// </summary>
    /// <param name="correctCoinAmount">boolean, true if number of coins matches condition</param>
    public void SetFinish(bool correctCoinAmount)
    {
        winnable = correctCoinAmount;
        finishCollider.isTrigger = winnable;

        if (winnable)
        {
            finishRenderer.material = finishOpen;
        }
        else
        {
            finishRenderer.material = finishClosed;
        }
    }
}
