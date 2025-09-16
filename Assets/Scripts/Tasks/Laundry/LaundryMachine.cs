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
    [SerializeField] public float time = 0f;

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
            laundryClothes.gameObject.SetActive(false); 
        }
    }
    public void UpdateProgressCircle() { progressImage.fillAmount = time / workTimeRequired; }
    public void IncrementTimer(float time)
    {
        if (this.time <= workTimeRequired) { this.time += time; UpdateProgressCircle(); } //Increase timer while not at required time
    }

    public void StartMachine(float time = 0f)
    {
        this.time = time;
    }
    public void ReleaseLoad() //Resets laundry machine and also spawns laundry in the air.
    {
        Debug.Log("Releasing Clothes");
    }
    public void OpenCloseMachine()
    {
        if(time >= workTimeRequired && machineSprite.sprite == closedSprite) { ReleaseLoad(); }

        if (machineSprite.sprite == openSprite)
        {
            machineSprite.sprite = closedSprite; 
            startMachineButton.gameObject.SetActive(true);
        }
        else 
        {
            machineSprite.sprite = openSprite; startMachineButton.gameObject.SetActive(false);
            if (time >= workTimeRequired) { ReleaseLoad(); }
        }
    }
    public void OnDestroy()
    {
        if(laundryAccepts == Laundry.Dirty) { laundryTaskSettings.WashingMachineTimeLeft = workTimeRequired - time; }
        if(laundryAccepts == Laundry.Wet) { laundryTaskSettings.DryingMachineTimeLeft = workTimeRequired - time; }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Laundry"))
        {

        }
    }
}
public enum Laundry
{
    Clean,
    Dirty,
    Wet,
}