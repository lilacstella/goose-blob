using UnityEngine;

public class TrashSpawner : MonoBehaviour
{
    public GameObject[] trashPrefabs;
    public Transform[] spawnPoints;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // void Start()
    // {
    //     int hi = GameManager.Instance.TrashSpawnTier;
    // }

    // Update is called once per frame
    // void Update()
    // {
    // }
    
    void SpawnTrash()
    {
        int rand = Random.Range(0, trashPrefabs.Length);
        Instantiate(trashPrefabs[rand], transform.position, transform.rotation);
    }
}
