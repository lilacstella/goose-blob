using UnityEngine;

[CreateAssetMenu(fileName = "Teeth Brushing Task Settings", menuName = "Tasks/Teeth Brushing/Task Settings")]
public class TeethBrushingTaskSettings : TaskSettings
{
    [Range(0f, 1f)] public float dirtinessLevel = 0.5f;
}
