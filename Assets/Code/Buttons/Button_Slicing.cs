using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Scripting.Python;

public class Button_Slicing : Button
{
    [SerializeField] FallingPillar[] pillars = new FallingPillar[9];

    [SerializeField] bool[] pythonPillars= new bool[9];

    [SerializeField] PillarType buttonPillarType;

    [SerializeField] Material buttonMaterial;
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
            foreach (FallingPillar pillar in pillars)
            {
                pillar.gameObject.GetComponentInChildren<Renderer>().material.color = Color.green;
                pillar.DropPillar();
            }
        }
    }

    public override void HoverOffButton()
    {
        GetComponent<Renderer>().material = buttonMaterial;
    }
}
