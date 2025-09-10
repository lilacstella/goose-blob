using UnityEngine;

public class BrushTeethTask : Task
{
    public GameObject toothBrush;
    public GameObject mouthAndTeeth;
    public GameObject table;

    public void Start()
    {
        ShowHideTaskObjects(false);
    }

    private void ShowHideTaskObjects(bool activeornot)
    {
        toothBrush.SetActive(activeornot);
        mouthAndTeeth.SetActive(activeornot);
        table.SetActive(activeornot);
    }

    public override void StartTask()
    {
        if (PlayerInRange)
        {
            if (TaskManager.Instance.StartTask(this))
            {
                OnStartTask.Invoke();
                PassTimeForTask();
                SceneManager.Instance.SwitchScene(taskScene, () => _col.gameObject.SetActive(false));
            }
        }
    }

    public override void CompleteTask()
    {
        if (TaskManager.Instance.CompleteTask(this))
        {
            ShowHideTaskObjects(false);
            _col.enabled = true;
        }
    }
}
