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
    [SerializeField] int currentCoinCount = 0;
    [SerializeField] int totalCoinCount;

    [SerializeField] Material finishOpen, finishClosed;
    [SerializeField] GameObject finishObject;
    [SerializeField] TextMeshProUGUI coinCounter;

    [SerializeField] TextMeshProUGUI[] tasksUI = new TextMeshProUGUI[6];
    [SerializeField] bool[] tasks = new bool[6];

    LevelController levelController;
    Renderer finishRenderer;
    Collider finishCollider;

    bool winnable = false;

    private void Start()
    {
        finishRenderer = finishObject.GetComponent<Renderer>();
        finishCollider = finishObject.GetComponent<Collider>();

        levelController = FindObjectOfType<LevelController>();
        totalCoinCount = GameObject.FindGameObjectsWithTag("coin").Length;
        UpdateCoinCounter();

        SetFinish(false);
        
        PythonRunner.RunFile($"{Application.dataPath}/code/lesson03.py");
        CheckTasks();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("finish"))
        {
            levelController.EndLevel(true);
        }
    }

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

    public int GetCoinCount()
    {
        return currentCoinCount;
    }

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

    void UpdateCoinCounter()
    {
        coinCounter.text = "Coins: " + currentCoinCount + "/" + totalCoinCount;
    }

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
        tasks[5] = winnable && currentCoinCount == 1 || currentCoinCount == 6;

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
}
