using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class Task : MonoBehaviour
{
    public UnityEvent OnCompleteTask, OnStartTask;
    public int chanceForTimeToFlyBy = 0;
    public int minutesToFlyBy = 20;
    public bool PlayerInRange { get; protected set; } 
    protected Collider2D _col;

    private void Awake()
    {
        PlayerInRange = false;
        _col = GetComponent<Collider2D>();
    }

    public void TryForTimeFlyBy()
    {
        if(TimeManager.Instance != null)
        {
            if(Random.Range(0, 100) <= chanceForTimeToFlyBy)
            {
                TimeManager.Instance.AddTime(minutesToFlyBy);
            }
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) { PlayerInRange = true; }
    }

    public abstract void CompleteTask();
    public abstract void StartTask();

    public void OnMouseDown()
    {
        StartTask();
    }
}
