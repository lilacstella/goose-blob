using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    public static TaskManager Instance { get; private set; }
    
    public Task CurrentTask { get; private set; }

    [SerializeField] List<Tasks> _requiredTasks;

    [SerializeField] GameObject trashTaskPrefab;    

    [SerializeField] LevelSettings selectedLevelSettings;

    private void Awake()
    {
        if(Instance == null) { Instance = this; DontDestroyOnLoad(this); }
        else { Destroy(this); }
    }

    void Start()
    {
        CurrentTask = null;
        SceneManager.Instance.OnSceneSwitch.AddListener(ResetTaskManager);

        SetTasksForNewLevel();
    }

    
    public void SetTasksForNewLevel()
    {
        if (selectedLevelSettings == null) { Debug.LogError("Missing Level Settings!!!"); return; }

        foreach (TaskSettings task in selectedLevelSettings.requiredTasks)
        {
            switch (task.taskType)
            {
                case Tasks.TakeOutTrash:
                    _requiredTasks.Add(Tasks.TakeOutTrash);
                    Instantiate(trashTaskPrefab, this.transform).GetComponent<TrashTask>().settings = (TrashTaskSettings)task;
                    break;
            }
        }
    }

    public void ResetTaskManager(int scene)
    {
        if (scene == 0) 
        {
            CurrentTask = null;
            _requiredTasks.Clear();
        }
    }

    private void Update()
    {
        if (HasTask) 
        {
            
        }
    }

    public bool StartTask(Task task)
    {
        if (!HasTask)
        {
            CurrentTask = task;
            CurrentTask.OnStartTask.Invoke();
            return true;
        }
        return false;
    }

    public bool CompleteTask(Task task)
    {
        if (CurrentTask == task)
        {
            _requiredTasks.Remove(task.settings.taskType);
            CurrentTask.OnCompleteTask.Invoke();
            CurrentTask = null;
            Destroy(task.gameObject);
            return true;
        }
        return false;
    }

    public bool HasTask => CurrentTask != null;
}
