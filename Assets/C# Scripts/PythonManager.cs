using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Scripting.Python;

public class PythonManager
{
    public static void RunLevel(string levelNumber)
    {
        PythonRunner.RunFile($"{Application.dataPath}/Python/lesson0" + levelNumber + ".py");
    }

    public static void RunBlueRoom()
    {
        PythonRunner.RunFile($"{Application.dataPath}/Python/lesson06/BlueRoom.py");
    }

    public static void RunRedRoom()
    {
        PythonRunner.RunFile($"{Application.dataPath}/Python/lesson06/RedRoom.py");
    }

    public static void RunOrangeRoom()
    {
        PythonRunner.RunFile($"{Application.dataPath}/Python/lesson06/OrangeRoom.py");
    }

    public static void RunGreenRoom()
    {
        PythonRunner.RunFile($"{Application.dataPath}/Python/lesson06/GreenRoom.py");
    }

    public static void RunYellowRoom()
    {
        PythonRunner.RunFile($"{Application.dataPath}/Python/lesson06/YellowRoom.py");
    }

    public static void RunWhiteRoom(string pillarColour)
    {
        PythonRunner.RunFile($"{Application.dataPath}/Python/lesson06/WhiteRoom_" + pillarColour + ".py");
    }
}
