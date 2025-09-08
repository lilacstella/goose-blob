using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class TrashSpawner : MonoBehaviour
{
    public GameObject[] smallTrashObjects;
    public GameObject trashBag;
    public GameObject cardboardBox;
    public List<Rigidbody2D> smallTrashList, trashBagsList, cardboardBoxList;
    public float velocityThreshold = 1.0f;

    public TrashSettings settings;

    public Transform[] spawnPoints;

    private void Start()
    {
        if (settings != null)
        {
            SpawnTrash();
        }
    }

    public bool CheckIfTrashIsStable()
    {
        foreach (Rigidbody2D rb in smallTrashList) { if (rb.linearVelocity.magnitude > velocityThreshold) { return false; } }
        foreach (Rigidbody2D rb in trashBagsList) { if (rb.linearVelocity.magnitude > velocityThreshold) { return false; } }
        foreach (Rigidbody2D rb in cardboardBoxList) { if (rb.linearVelocity.magnitude > velocityThreshold) { return false; } }
        return true;
    }

    void SpawnTrash()
    {
        int pos = 0;
        for (int i = 0; i < settings.smallTrashLeft; i++)
        {
            int rand = Random.Range(0, smallTrashObjects.Length);
            GameObject gameObject = Instantiate(smallTrashObjects[rand], spawnPoints[pos++].position, Quaternion.identity);
            gameObject.GetComponent<Collider2D>().enabled = false;
            smallTrashList.Add(gameObject.GetComponent<Rigidbody2D>());
        }
        for (int i = 0; i < settings.trashBagLeft; i++)
        {
            GameObject gameObject = Instantiate(trashBag, spawnPoints[pos++].position, Quaternion.identity);
            gameObject.GetComponent<Collider2D>().enabled = false;
            float scale = Random.Range(0.8f, 1.72f);
            gameObject.transform.localScale = Vector3.one * scale;
            trashBagsList.Add(gameObject.GetComponent<Rigidbody2D>());

        }
        for (int i = 0; i < settings.cardboardBoxLeft; i++)
        {
            GameObject gameObject = Instantiate(cardboardBox, spawnPoints[pos++].position, Quaternion.identity);
            gameObject.GetComponent<Collider2D>().enabled = false;
            float scale = Random.Range(1.5f, 2.58f);
            gameObject.transform.localScale = new Vector3(scale, 1f, 1f);
            cardboardBoxList.Add(gameObject.GetComponent<Rigidbody2D>());
        }
    }

    public void ExitTask()
    {

    }
}
