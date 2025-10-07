using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class LaundryController : MonoBehaviour
{
    public LaundryTask laundryTask;
    public LaundryTaskSettings settings;
    public LaundryMachine washingMachine;
    public LaundryMachine dryingMachine;

    [SerializeField] GameObject[] laundryPrefabs;
    [SerializeField] Transform[] spawnPoints;

    private void Start()
    {
        TaskManager.Instance.onDone.AddListener(()=> SceneManager.Instance.SwitchScene(SceneManager.Scenes.GAME_SCENE));
    }

    public void LoadLaundryFromSettings()
    {
        washingMachine.settings = settings;
        dryingMachine.settings = settings;
        if (settings.washerWorking && settings.WashingMachineTimeLeft > 0f) 
        {
            
            washingMachine.StartMachine(settings.WashingMachineTimeLeft); 
            for(int i = 0; i < settings.dirtyLaundryInWasher; i++)
            {
                Instantiate(laundryPrefabs[Random.Range(0, laundryPrefabs.Length)], washingMachine.transform.position, Quaternion.identity);
            }
        }
        if (settings.dryerWorking && settings.DryingMachineTimeLeft > 0f) 
        {
            dryingMachine.StartMachine(settings.DryingMachineTimeLeft);
            for (int i = 0; i < settings.dirtyLaundryInWasher; i++)
            {
                Instantiate(laundryPrefabs[Random.Range(0, laundryPrefabs.Length)], dryingMachine.transform.position, Quaternion.identity);
            }
        }

        if (settings.dirtyLaundry > 0)
        {
            for (int i = 0; i < settings.dirtyLaundry; i++)
            {
                Instantiate(laundryPrefabs[Random.Range(0, laundryPrefabs.Length)], spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
            }
        }
    }

    public void Update()
    {
        if (washingMachine.MachineWorking) { washingMachine.IncrementTimer(Time.deltaTime); }
        if (dryingMachine.MachineWorking) { dryingMachine.IncrementTimer(Time.deltaTime); }
    }
}
