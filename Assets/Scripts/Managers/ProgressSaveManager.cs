using UnityEngine;

public class ProgressSaveManager : MonoBehaviour
{
    public static ProgressSaveManager Instance;

    private void Awake()
    {
        if(Instance == null) { Instance = this; DontDestroyOnLoad(this); }
        else { Destroy(gameObject); }
    }

    public void ClearAllData()
    {
        PlayerPrefs.DeleteAll();
    }
}
