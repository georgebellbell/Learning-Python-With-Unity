using System.Collections.Generic;
using UnityEditor.Scripting.Python;
using UnityEngine;
using Random = UnityEngine.Random;

public class Button_Coloured_Platforms : Button
{
    [SerializeField] GameObject[] platforms;
    [SerializeField] List<float> initalZPosition;

    [SerializeField] List<GameObject> randomPlatforms;

    [SerializeField] string[] platformOrder = new string[7];
    [SerializeField] int[] platformOrderInt = new int[7];

    /// <summary>
    /// Overrides start function of button to randomly shuffle order of platforms
    /// </summary>
    public override void StartButton()
    {
        base.StartButton();
        
        SetPlatformTransforms();
        RandomisePlatforms();
        SetPlatformPositions();
    }

    /// <summary>
    /// Add platforms and their inital z positions to respective lists
    /// </summary>
    private void SetPlatformTransforms()
    {
        for (int i = 0; i < platforms.Length; i++)
        {
            randomPlatforms.Add(platforms[i]);
            initalZPosition.Add(platforms[i].transform.position.z);
        }
    }
    
    /// <summary>
    /// Randomise order of random platforms list
    /// </summary>
    void RandomisePlatforms()
    {
        for (int i = 0; i < randomPlatforms.Count; i++)
        {
            GameObject temp = randomPlatforms[i];
            int randomIndex = Random.Range(i, initalZPosition.Count);
            randomPlatforms[i] = randomPlatforms[randomIndex];
            randomPlatforms[randomIndex] = temp;
        }
    }

    /// <summary>
    /// Change positions of pillars to reflect shuffling
    /// </summary>
    private void SetPlatformPositions()
    {
        for (int i = 0; i < randomPlatforms.Count; i++)
        {
            randomPlatforms[i].transform.position = new Vector3(randomPlatforms[i].transform.position.x,
                                                                randomPlatforms[i].transform.position.y,
                                                                initalZPosition[i]);
        }
    }

    /// <summary>
    /// Override Activate button function to run python code to order platforms
    /// </summary>
    public override void ActivateButton()
    {
        base.ActivateButton();
        PythonRunner.RunFile($"{Application.dataPath}/code/lesson06/04.py");
    }

    /// <summary>
    /// Called via python code to retrieve current (randomised) order of platforms as their respective colour
    /// </summary>
    /// <returns>string[], array of strings for each platform colour</returns>
    public string[] GetPlatformColours()
    {
        for (int i = 0; i < randomPlatforms.Count; i++)
        {
            platformOrder[i] = randomPlatforms[i].gameObject.name;              
        }
        
        return platformOrder;
    }

    /// <summary>
    /// Called via python code to retrieve current (randomised) order of platforms as their respective heights
    /// </summary>
    /// <returns>int[], array of integers for each platform height</returns>
    public int[] GetPlatformHeights()
    {
        for (int i = 0; i < randomPlatforms.Count; i++)
        {
            switch (randomPlatforms[i].gameObject.name)
            {
                case "red":
                    platformOrderInt[i] = 1;
                    break;
                case "orange":
                    platformOrderInt[i] = 2;
                    break;
                case "yellow":
                    platformOrderInt[i] = 3;
                    break;
                case "green":
                    platformOrderInt[i] = 4;
                    break;
                case "blue":
                    platformOrderInt[i] = 5;
                    break;
                case "indigo":
                    platformOrderInt[i] = 6;
                    break;
                case "violet":
                    platformOrderInt[i] = 7;
                    break;
            }
        }

        return platformOrderInt;

    }

    /// <summary>
    /// Called via python code to set platform positions based on order of colours passed in 
    /// </summary>
    /// <param name="newPlatformOrder">array of colours representing the respective platforms</param>
    public void PythonPlatformPositioning(string[] newPlatformOrder)
    {
        for (int i = 0; i < newPlatformOrder.Length; i++)
        {
            GameObject currentPlatform;
            switch (newPlatformOrder[i])
            {
                case "red":
                    currentPlatform = platforms[0];
                    break;
                case "orange":
                    currentPlatform = platforms[1];
                    break;
                case "yellow":
                    currentPlatform = platforms[2];
                    break;
                case "green":
                    currentPlatform = platforms[3];
                    break;
                case "blue":
                    currentPlatform = platforms[4];
                    break;
                case "indigo":
                    currentPlatform = platforms[5];
                    break;
                case "violet":
                    currentPlatform = platforms[6];
                    break;
                default:
                    currentPlatform = null;
                    break;
            }

            currentPlatform.transform.position = new Vector3(currentPlatform.transform.position.x,
                                                             currentPlatform.transform.position.y,
                                                             initalZPosition[i]);

        }
    }
}
