using System.Security;
using UnityEngine;
using UnityEngine.UI;

public class LaundryMachine : MonoBehaviour
{
    [SerializeField] Button startMachineButton;
    [SerializeField] Image progressImage;
    [SerializeField] AudioSource laundryAudioSource;
    [SerializeField] LaundryTaskSettings laundryTaskSettings;
    [Header("Settings")]
    [SerializeField] Laundry laundryAccepts;
    [SerializeField] float washingTime, dryingTime;

    [SerializeField] GameObject laundryDirty, laundryWet, laundryClean;

    public void UpdateProgressCircle()
    {

    }
}
public enum Laundry
{
    Clean,
    Dirty,
    Wet,
}