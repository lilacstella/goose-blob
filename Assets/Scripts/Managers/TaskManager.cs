using UnityEngine;

public class TaskManager : MonoBehaviour
{
    public static TaskManager Instance { get; private set; }
    
    public Task CurrentTask { get; private set; }

    public LevelSettings selectedLevelSettings;
    public TrashTaskSettings trashTaskSettings;

    private void Awake()
    {
        if(Instance == null) { Instance = this; DontDestroyOnLoad(this); }
        else { Destroy(this); }
    }

    void Start()
    {
        CurrentTask = null;
    }

    public void ResetTaskManager()
    {

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
            task.transform.SetParent(this.transform);
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
            CurrentTask.OnCompleteTask.Invoke();
            task.transform.SetParent(null);
            CurrentTask = null;
            return true;
        }
        return false;
    }

    public bool HasTask => CurrentTask != null;
}
