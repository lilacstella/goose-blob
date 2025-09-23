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
    [SerializeField] protected bool _requirePlayerInRange = true;
    public Collider2D _col;
    public bool TaskComplete { get; set; }

    public TaskSettings settings;

    private void Awake()
    {
        PlayerInRange = false;
        TaskComplete = false;
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
            SceneManager.Instance.SwitchScene(SceneManager.Scenes.GAME_SCENE, ()=> _col.gameObject.SetActive(true));
            OnCompleteTask.Invoke();
        }
    }
    public virtual void StartTask()
    {
        if (_requirePlayerInRange && !PlayerInRange) { return; }
        
        if (TaskManager.Instance.StartTask(this))
        {
            OnStartTask.Invoke();
            PassTimeForTask();
            SceneManager.Instance.SwitchScene(taskScene, () => _col.gameObject.SetActive(false));
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