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
    [SerializeField] FallingPillar[] pillars = new FallingPillar[9];

    [SerializeField] bool[] pythonPillars= new bool[9];

    [SerializeField] PillarType buttonPillarType;

    [SerializeField] string filename;

    public override void ActivateButton()
    {
        base.ActivateButton();
        PythonRunner.RunFile($"{Application.dataPath}/code/lesson06/02_" + filename + ".py");
        SlicePillars();
    }

    public void SetPythonPillars(bool[] newList)
    {
        pythonPillars = newList;
    }

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

    private void DropPillars()
    {
        foreach (FallingPillar pillar in pillars)
        {
            pillar.gameObject.GetComponentInChildren<Renderer>().material.color = Color.green;
            pillar.DropPillar();
        }
    }
}
