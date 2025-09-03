using UnityEngine;

public class TaskTrigger : MonoBehaviour
{
    public Task task;
    private void Awake()
    {
        task = GetComponent<Task>();
    }

    private void OnMouseDown()
    {
        if(TaskManager.Instance != null && task != null)
        {
            TaskManager.Instance.StartTask(task);
        }
    }
}
