using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level Settings", menuName = "Levels/Level Settings")]
public class LevelSettings : ScriptableObject
{
    public int startingTime = 360; //6 am
    public List<TaskSettings> requiredTasks;
    public int startingGuilt;
}
