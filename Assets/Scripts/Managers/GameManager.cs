using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public TrashSettings trashSettings;

    private int trashSpawnTier;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
            Destroy(this);
    }



    public int TrashSpawnTier
    {
        get { return trashSpawnTier; }
        set { trashSpawnTier = value; }
    }
}
