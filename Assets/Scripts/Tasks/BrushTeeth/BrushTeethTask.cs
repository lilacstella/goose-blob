using UnityEngine;

public class BrushTeethTask : Task
{
    [SerializeField] GameObject _brushTeethSprites;
    [SerializeField] Mouth _mouth;

    public void Start()
    {
        OnCompleteTask.AddListener(()=> _brushTeethSprites.SetActive(false));
        _brushTeethSprites.SetActive(false);
    }

    private void Update()
    {
        if()
    }

    public override void StartTask()
    {
        if (_requirePlayerInRange && !PlayerInRange) { return; }

        if (TaskManager.Instance.StartTask(this))
        {
            OnStartTask.Invoke();
            PassTimeForTask();
            SceneManager.Instance.SwitchScene(taskScene, StartBrushTask);
        }

        void StartBrushTask()
        {
            _col.gameObject.SetActive(false);
            _brushTeethSprites.SetActive(true);
        }
    }
}