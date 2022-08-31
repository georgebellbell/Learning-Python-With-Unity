/*
 * 
 * Author: George Bell
 * Since:  07-07-2022
 * Organisation: Newcastle University
 * 
*/
using UnityEngine;
using UnityEditor.Scripting.Python;

public class Button_Slicing : Button
{
    [Header("Pillar Details")]
    [SerializeField] FallingPillar[] pillars = new FallingPillar[9];
    [SerializeField] bool[] pythonPillars= new bool[9];

    [Header("Pillar Type Details")]
    [SerializeField] PillarType buttonPillarType;
    [SerializeField] string filename;

    /// <summary>
    /// overrides AcitvateButton to run python code and check all pillars
    /// </summary>
    public override void ActivateButton()
    {
        base.ActivateButton();
        PythonManager.RunWhiteRoom(filename);
        //PythonRunner.RunFile($"{Application.dataPath}/code/lesson06/02_" + filename + ".py");
        SlicePillars();
    }
    
    /// <summary>
    /// iterates through each pillar, checking them against pythonPillars (updated via python).
    /// if true will set python pillar to the colour of that button.
    /// checks status of all pillars
    /// </summary>
    private void SlicePillars()
    {
        for (int i = 0; i < pillars.Length; i++)
        {
            if (pythonPillars[i])
            {
                pillars[i].ActivatePillar(buttonPillarType);
            }
        }

        CheckPillarsStatus();
    }

    /// <summary>
    /// All pillars are checked, with their status retrieved. If any colours don't match pillar type, they wont drop
    /// </summary>
    private void CheckPillarsStatus()
    {
        bool taskAccomplished = false;
        foreach (FallingPillar fallingPlatform in pillars)
        {
            bool pillarStatus = fallingPlatform.GetPillarStatus();
            if(pillarStatus)
            {
                taskAccomplished = true;
            }
            else
            {
                taskAccomplished = false;
                break;
            }
        }

        if (taskAccomplished)
        {
            DropPillars();
        }
    }

    /// <summary>
    /// Turn all pillars green and drop them all, allowing progression
    /// </summary>
    private void DropPillars()
    {
        foreach (FallingPillar pillar in pillars)
        {
            pillar.gameObject.GetComponentInChildren<Renderer>().material.color = Color.green;
            pillar.DropPillar();
        }
    }

    /// <summary>
    /// Used by Python to set the values of pythonPillars
    /// </summary>
    /// <param name="newList">array of booleans for a specific button colour</param>
    public void SetPythonPillars(bool[] newList)
    {
        pythonPillars = newList;
    }
}
