using UnityEngine;

public class TrashSpawner : MonoBehaviour
{
    public GameObject[] trashPrefabs;

    public float spawnRate;
    private float timer = 0;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer = spawnRate;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
            timer += Time.deltaTime;
        else
        {
            SpawnTrash();
            timer = 0;
        }
    }
    
    void SpawnTrash()
    {
        int rand = Random.Range(0, trashPrefabs.Length);
        Instantiate(trashPrefabs[rand], transform.position, transform.rotation);
    }
}
