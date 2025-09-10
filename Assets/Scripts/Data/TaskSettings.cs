using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Task Settings", menuName = "Tasks/TaskSettings")]
public class TaskSettings : ScriptableObject
{
    public Tasks taskType;
    public GuiltSettings guiltSettings;
    public int chancesToFail = 3;
    public int baseTimeUsage = 15;
}
