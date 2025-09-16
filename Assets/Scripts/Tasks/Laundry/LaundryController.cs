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

    public void StartWashingMachine()
    {
        //play beep audio
        //start countdown

    }
    public void ReleaseLoad()
    {

    }
    public void StartDryingMachine()
    {

    }
}
