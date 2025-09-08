using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class Task : MonoBehaviour
{
    public UnityEvent OnCompleteTask, OnStartTask;
    public int chanceForTimeToFlyBy = 0;
    public int minutesToFlyBy = 20;
    public SceneManager.Scenes taskScene;
    public bool PlayerInRange { get; protected set; } 
    public Collider2D _col;

    public TaskSettings settings;

    private void Awake()
    {
        PlayerInRange = false;
    }

    public void PassTimeForTask()
    {
        if(TimeManager.Instance != null)
        {
            TimeManager.Instance.AddTime(minutesToFlyBy);
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) { PlayerInRange = true; }
    }

    public virtual void CompleteTask()
    {
        if (TaskManager.Instance.CompleteTask(this))
        {
            _col.enabled = true;
            SceneManager.Instance.SwitchScene(SceneManager.Scenes.GAME_SCENE);
            OnCompleteTask.Invoke();
        }
    }
    public virtual void StartTask()
    {
        if (PlayerInRange)
        {
            if (TaskManager.Instance.StartTask(this))
            {
                _col.enabled = false;
                PassTimeForTask();
                SceneManager.Instance.SwitchScene(taskScene);
                OnStartTask.Invoke();
            }
        }
    }

    public void OnMouseDown()
    {
        StartTask();
    }
}
public enum Tasks
{
    None, 
    TakeOutTrash,
    Laundry,
    BrushYourTeeth,
    Cooking,
    Showering,

}