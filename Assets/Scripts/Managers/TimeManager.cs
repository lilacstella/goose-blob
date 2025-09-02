using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public int CurrentTime { get; private set; }

    //1 second in game = 1 minute on the clock. 
    //480 in current time = 8 AM. 720 = 12:00. 960 = 16:00.

    public static TimeManager Instance;
    public void Awake()
    {
        if (Instance == null) { Instance = this; }
        else { Destroy(this); }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) { CurrentTime = Random.Range(1, 1000);  Debug.Log(GetCurrentTimeAsString()); }
    }

    public string GetCurrentTimeAsString()
    {
        int h = 0;
        int t = CurrentTime;
        while(t >= 60) { h++; t -= 60; }

        return h.ToString() + ":" + t.ToString();
    }
}
