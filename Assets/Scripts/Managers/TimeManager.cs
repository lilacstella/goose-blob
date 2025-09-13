using TMPro;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class TimeManager : MonoBehaviour
{
    public float CurrentTime { get; private set; }
    public bool timePaused = false;
    public TMP_Text timeText;
    public int startingTime = 480;
    public float timePerMinute = 60;
    public bool timeIncreasesAutomatically = true;
    [SerializeField] CanvasGroup _timeCanvas; 
    //1 second in game = 1 minute on the clock. 
    //480 in current time = 8 AM. 720 = 12:00. 960 = 16:00.

    public static TimeManager Instance;
    public void Awake()
    {
        if (Instance == null) { Instance = this; DontDestroyOnLoad(this); }
        else { Destroy(this); }

        _timeCanvas = GetComponent<CanvasGroup>();
    }

    private void Start()
    {
        CurrentTime = startingTime;

        if (SceneManager.Instance != null) { SceneManager.Instance.OnSceneSwitch.AddListener(PauseOnSwitchOutOfGameScene); }
        else { Debug.LogWarning("Missing SceneManager! Unable to switch scenes!"); }
    }
    private void PauseOnSwitchOutOfGameScene(int scene)
    {
        if(scene == (int)SceneManager.Scenes.GAME_SCENE) { timePaused = false; _timeCanvas.alpha = 1f; }
        else { timePaused = true; _timeCanvas.alpha = 0f; }
    }
    private void Update()
    {
        if(timePaused) { return; }

        if (timeIncreasesAutomatically) CurrentTime += timePerMinute * Time.deltaTime / 60f;

        if (timeText != null) { timeText.text = GetCurrentTimeAsString(); }
    }
    public void AddTime(float time)
    {
        CurrentTime += time;
        if (CurrentTime <= 0) { CurrentTime = 0; }
        else if (CurrentTime > 1440f) { CurrentTime = 0; } //If current time is exactly midnight, set to 0. 
    }
    public string GetCurrentTimeAsString()
    {
        int h = 0;
        int t = Mathf.RoundToInt(CurrentTime);
        while(t >= 60) { h++; t -= 60; }

        return string.Format("{0:00}:{1:00}", h, t);
    }
}
