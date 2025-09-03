using UnityEngine;

public class TaskManager : MonoBehaviour
{
    public static TaskManager Instance { get; private set; }
    
    public Task CurrentTask { get; private set; }
    
    private void Awake()
    {
        if(Instance == null) { Instance = this; }
        else { Destroy(this); }
    }

    void Start()
    {
        CurrentTask = null;
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
            CurrentTask.OnCompleteTask.Invoke();
            CurrentTask = null;
            return true;
        }
        return false;
    }

    public bool HasTask => CurrentTask != null;
}
