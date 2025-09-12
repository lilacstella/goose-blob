using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TrashSpawner : MonoBehaviour
{
    public GameObject[] smallTrashObjects;
    public GameObject trashBag;
    public GameObject cardboardBox;
    public List<Rigidbody2D> smallTrashList, trashBagsList, cardboardBoxList;
    public List<GameObject> gameObjectsLeftOnFloor;

    public TrashController trashController;

    public Transform[] spawnPoints;

    private void Start()
    {
        // if (TaskManager.Instance != null) settings = (TrashTaskSettings)TaskManager.Instance.CurrentTask.settings;
        // if (settings != null)
        // {
        SpawnTrash();
        // }
    }

    void SpawnTrash()
    {
        int pos = 0;
        for (int i = 0; i < trashController.smallTrashCount; i++)
        {
            int rand = Random.Range(0, smallTrashObjects.Length);
            GameObject gameObject = Instantiate(smallTrashObjects[rand], spawnPoints[pos++].position, Quaternion.identity);
            gameObject.GetComponent<Collider2D>().enabled = false;
            smallTrashList.Add(gameObject.GetComponent<Rigidbody2D>());
        }
        for (int i = 0; i < trashController.trashBagCount; i++)
        {
            GameObject gameObject = Instantiate(trashBag, spawnPoints[pos++].position, Quaternion.identity);
            gameObject.GetComponent<Collider2D>().enabled = false;
            float scale = Random.Range(0.8f, 1.3f);
            gameObject.transform.localScale = Vector3.one * scale;
            trashBagsList.Add(gameObject.GetComponent<Rigidbody2D>());

        }
        for (int i = 0; i < trashController.cardboardBoxCount; i++)
        {
            GameObject gameObject = Instantiate(cardboardBox, spawnPoints[pos++].position, Quaternion.identity);
            gameObject.GetComponent<Collider2D>().enabled = false;
            float scale = Random.Range(1.5f, 2.58f);
            gameObject.transform.localScale = new Vector3(scale, 1f, 1f);
            cardboardBoxList.Add(gameObject.GetComponent<Rigidbody2D>());
        }
    }

}
