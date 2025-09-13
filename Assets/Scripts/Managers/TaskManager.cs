using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TaskManager : MonoBehaviour
{
    public static TaskManager Instance { get; private set; }
    
    public Task CurrentTask { get; private set; }

    [SerializeField] CanvasGroup _taskManagerCanvas;
    [SerializeField] TMP_Text _taskButton;
    [SerializeField] List<Tasks> _requiredTasks;

    [SerializeField] GameObject trashTaskPrefab, teethBrushingTaskPrefab;    

    [SerializeField] LevelSettings selectedLevelSettings;

    private List<GameObject> _taskPrefabs;

    private void Awake()
    {
        if(Instance == null) { Instance = this; DontDestroyOnLoad(this); }
        else { Destroy(this); }

        _taskPrefabs = new List<GameObject>();
    }

    void Start()
    {
        CurrentTask = null;
        if (SceneManager.Instance != null) { SceneManager.Instance.OnSceneSwitch.AddListener(SwitchingScene); }
        else { Debug.LogWarning("Missing SceneManager! Unable to handle scene switching!"); }
        SetTasksForNewLevel();
    }

    
    public void SetTasksForNewLevel()
    {
        if (selectedLevelSettings == null) { Debug.LogError("Missing Level Settings!!!"); return; }

        foreach (TaskSettings task in selectedLevelSettings.requiredTasks)
        {
            GameObject taskPrefab = null;
            switch (task.taskType)
            {
                case Tasks.TakeOutTrash:
                    _requiredTasks.Add(Tasks.TakeOutTrash);
                    taskPrefab = Instantiate(trashTaskPrefab, this.transform);
                    taskPrefab.GetComponent<TrashTask>().settings = (TrashTaskSettings)task;
                    break;
                case Tasks.BrushYourTeeth:
                    _requiredTasks.Add(Tasks.BrushYourTeeth);
                    taskPrefab = Instantiate(teethBrushingTaskPrefab, this.transform);
                    taskPrefab.GetComponent<BrushTeethTask>().settings = (TeethBrushingTaskSettings)task;
                    break;
                case Tasks.Laundry:

                    break;
                case Tasks.Showering:

                    break;
                case Tasks.Cooking:

                    break;
            }
            if(taskPrefab != null) { _taskPrefabs.Add(taskPrefab); }
            if (SceneManager.Instance.CurrentSceneIndex != 1) { taskPrefab.SetActive(false); }
        }
    }

    public void SwitchingScene(int scene)
    {
        if (scene == 0) 
        {
            CurrentTask = null;
            _requiredTasks.Clear();
            foreach(GameObject go in _taskPrefabs)
            {
                Destroy(go);
            }

        }
        else if(scene == 1)
        {
            foreach (GameObject go in _taskPrefabs) { go.SetActive(true); }
            _taskManagerCanvas.alpha = 0f;
        }
        else
        {
            foreach(GameObject go in _taskPrefabs)
            {
                if(go.GetComponent<Task>().settings.taskType != CurrentTask.settings.taskType) go.SetActive(false);
            }
            _taskManagerCanvas.alpha = 1f;
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
            CurrentTask.OnCompleteTask.Invoke();
            CurrentTask = null;

            if (task.TaskComplete)
            {
                _requiredTasks.Remove(task.settings.taskType);
                _taskPrefabs.Remove(task.gameObject);
                Destroy(task.gameObject);
            }
            return true;
        }
        return false;
    }

    public bool HasTask => CurrentTask != null;

    public void PressTaskButton()
    {
        if (CurrentTask.TaskComplete) { CompleteTask(CurrentTask); }
        else { }
    }
}
