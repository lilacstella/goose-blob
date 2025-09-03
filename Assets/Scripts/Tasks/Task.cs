using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class Task : MonoBehaviour
{
    public UnityEvent OnCompleteTask, OnStartTask;
    public int chanceForTimeToFlyBy = 0;
    public int minutesToFlyBy = 20;
    protected Collider2D _col;

    private void Awake()
    {
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
    public abstract void CompleteTask();
    public abstract void StartTask();

    public void OnMouseDown()
    {
        StartTask();
    }
}
