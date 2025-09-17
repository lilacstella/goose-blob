using System.Collections.Generic;
using System.Security;
using UnityEngine;
using UnityEngine.UI;

public class LaundryMachine : MonoBehaviour
{
    [SerializeField] Button startMachineButton, openMachineButton;
    [SerializeField] Image progressImage;
    [SerializeField] SpriteRenderer machineSprite;
    [SerializeField] Sprite closedSprite, openSprite;
    [SerializeField] AudioClip completeSfx, startSfx;
    [SerializeField] LaundryTaskSettings laundryTaskSettings;
    [Header("Settings")]
    [SerializeField] Laundry laundryAccepts;
    [SerializeField] float workTimeRequired = 100f;

    List<LaundryClothes> laundryInMachine = new List<LaundryClothes>();
    float time = 0f;
    public bool MachineWorking { get; set; }

    private void Awake()
    {
        progressImage.fillAmount = 0;
        startMachineButton.interactable = false;
        machineSprite.sprite = openSprite;
    }

    private void Update()
    {
        //if (Input.GetMouseButtonDown(0)) { IncrementTimer(Time.deltaTime); }
    }
    public void AddLaundryToMachine(LaundryClothes laundryClothes)
    {
        if (!laundryInMachine.Contains(laundryClothes)) 
        {
            laundryInMachine.Add(laundryClothes);
            laundryClothes.EnterMachine();
            laundryClothes.transform.position = transform.position + (Vector3)Random.insideUnitCircle * 0.7f; 
        }
        if (laundryInMachine.Count > 0) { startMachineButton.interactable = true; }
    }

    public void UpdateProgressCircle() { progressImage.fillAmount = time / workTimeRequired; }
    public void IncrementTimer(float time)
    {
        if (this.time <= workTimeRequired) { this.time += time; UpdateProgressCircle(); } //Increase timer while not at required time
        else { MachineWorking = false; }
    }

    public void StartMachine(float time = 0f)
    {
        startMachineButton.gameObject.SetActive(false);
        MachineWorking = true;
        this.time = time;
    }
    public void ReleaseLoad() //Resets laundry machine and also spawns laundry in the air.
    {
        foreach (LaundryClothes item in laundryInMachine) 
        {
            item.SwitchState((Laundry)(int)laundryAccepts++);
            item.ExitMachine(); 
        }
        laundryInMachine.Clear();
        time = 0f;
        progressImage.fillAmount = 0f;
    }
    public void OpenCloseMachine()
    {
        if (MachineWorking) { return; }

        if (machineSprite.sprite == openSprite)
        {
            machineSprite.sprite = closedSprite; 
            startMachineButton.gameObject.SetActive(true);
            if (laundryInMachine.Count > 0) { startMachineButton.interactable = true; }
            else { startMachineButton.interactable = false; }
        }
        else 
        {
            machineSprite.sprite = openSprite; 
            startMachineButton.gameObject.SetActive(false);

            if (time >= workTimeRequired) { ReleaseLoad(); }
        }
        
    }
    public void OnDestroy()
    {
        if(laundryAccepts == Laundry.Dirty) 
        {
            laundryTaskSettings.washerWorking = MachineWorking;
            laundryTaskSettings.WashingMachineTimeLeft = workTimeRequired - time;
            laundryTaskSettings.dirtyLaundryInWasher = laundryInMachine.Count;
        }
        if(laundryAccepts == Laundry.Wet) 
        {
            laundryTaskSettings.dryerWorking = MachineWorking;
            laundryTaskSettings.DryingMachineTimeLeft = workTimeRequired - time;
            laundryTaskSettings.wetLaundryInDryer = laundryInMachine.Count;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(MachineWorking || machineSprite == closedSprite) { return; }

        if (collision.CompareTag("Laundry"))
        {
            LaundryClothes lc = collision.GetComponent<LaundryClothes>();
            if(lc == null) { return; }
            if (lc.LaundryStatus == laundryAccepts) { AddLaundryToMachine(lc); }
        }
    }
}
public enum Laundry
{
    Dirty,
    Wet,
    Clean,
}