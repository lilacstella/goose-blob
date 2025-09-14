using UnityEngine;

[CreateAssetMenu(fileName = "Laundry Task Settings", menuName = "Tasks/Laundry/Task Settings")]
public class LaundryTaskSettings : TaskSettings
{
    public int dirtyLaundry;
    public int timeLimit;
}
