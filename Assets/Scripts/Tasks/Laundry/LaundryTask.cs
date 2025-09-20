using UnityEngine;

public class LaundryTask : Task
{
    [SerializeField] AudioSource laundryTaskAudio;

    LaundryTaskSettings laundrySettings;
    void Start()
    {
        laundrySettings = (LaundryTaskSettings)settings;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnDirtyLaundry()
    {

    }


}
