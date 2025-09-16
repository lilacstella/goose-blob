using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class LaundryController : MonoBehaviour
{
    public LaundryTask laundryTask;

    public LaundryMachine washingMachine;
    public LaundryMachine dryingMachine;

    private void Start()
    {
        
    }

    public void LoadLaundryFromSettings()
    {

    }

    public void Update()
    {
        if (washingMachine.MachineWorking) { washingMachine.IncrementTimer(Time.deltaTime); }
    }
}
