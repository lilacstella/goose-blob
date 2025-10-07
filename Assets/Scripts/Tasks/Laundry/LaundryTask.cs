using Unity.VisualScripting;
using UnityEngine;

public class LaundryTask : Task
{
    [SerializeField] AudioSource laundryTaskAudio;

    LaundryTaskSettings laundrySettings;
    void Start()
    {
        laundrySettings = (LaundryTaskSettings)settings;
        TaskComplete = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnDirtyLaundry()
    {

    }

    public override void StartTask()
    {
        if (_requirePlayerInRange && !PlayerInRange) { return; }

        if (TaskManager.Instance.StartTask(this))
        {
            OnStartTask.Invoke();
            PassTimeForTask();
            SceneManager.Instance.SwitchScene(taskScene, SwitchScene);
        }

        void SwitchScene()
        {
            LaundryController lc = FindAnyObjectByType(typeof(LaundryController)).GetComponent<LaundryController>();
            lc.laundryTask = this;
            lc.settings = laundrySettings;
            lc.LoadLaundryFromSettings();

            _col.gameObject.SetActive(false);
            Debug.Log(lc);
        }
    }
}
