using UnityEngine;

public class TrashController : MonoBehaviour
{
    public TrashSettings settings;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // transfer all settings access to here instead, and trash spawner relies on trash controller
    }

    public void trackTrashLost(GameObject gameObject)
    {
        Debug.Log(gameObject);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
