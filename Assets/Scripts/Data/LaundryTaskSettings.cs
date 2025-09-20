using UnityEngine;

[CreateAssetMenu(fileName = "Laundry Task Settings", menuName = "Tasks/Laundry/Task Settings")]
public class LaundryTaskSettings : TaskSettings
{
    [Header("Settings")]
    public int dirtyLaundry;

    [Header("Do Not Change")]
    public bool washerWorking;
    public bool dryerWorking;

    public float WashingMachineTimeLeft;
    public float DryingMachineTimeLeft;

    public int dirtyLaundryInWasher, wetLaundryInDryer;
    public int dirtyLaundryPickedup;
}
