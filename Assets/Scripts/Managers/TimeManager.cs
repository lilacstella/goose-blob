using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float CurrentTime { get; private set; }
    public TMP_Text timeText;
    public int startingTime = 480;
    public float timePerMinute = 60;
    public bool timeIncreasesAutomatically = true;
    //1 second in game = 1 minute on the clock. 
    //480 in current time = 8 AM. 720 = 12:00. 960 = 16:00.

    public static TimeManager Instance;
    public void Awake()
    {
        if (Instance == null) { Instance = this; }
        else { Destroy(this); }
    }

    private void Start()
    {
        CurrentTime = startingTime;
    }

    private void Update()
    {
        if (timeIncreasesAutomatically) CurrentTime += timePerMinute * Time.deltaTime / 60f;

        if (Input.GetKeyDown(KeyCode.Space)) { CurrentTime = Random.Range(1, 1000);  Debug.Log(GetCurrentTimeAsString()); }

        if (timeText != null) { timeText.text = GetCurrentTimeAsString(); }
    }

    public string GetCurrentTimeAsString()
    {
        int h = 0;
        int t = Mathf.RoundToInt(CurrentTime);
        while(t >= 60) { h++; t -= 60; }

        return string.Format("{0:00}:{1:00}", h, t);
        //return h.ToString() + ":" + t.ToString();
    }
}
