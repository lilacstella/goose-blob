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
        if(settings != null)
        {
            SpawnTrash(settings.trashData);
        }
    }

    public bool CheckIfTrashIsStable()
    {
        foreach (Rigidbody2D rb in smallTrashList) { if(rb.linearVelocity.magnitude > velocityThreshold) { return false; } }
        foreach (Rigidbody2D rb in trashBagsList) { if(rb.linearVelocity.magnitude > velocityThreshold) { return false; } }
        foreach (Rigidbody2D rb in cardboardBoxList) { if(rb.linearVelocity.magnitude > velocityThreshold) { return false; } }
        return true;
    }

    void SpawnTrash(TrashData data)
    {
        int length = smallTrashObjects.Length;
        int pos = 0;
        for (int i = 0; i < data.smallTrashCount; i++) smallTrashList.Add(Instantiate(smallTrashObjects[Random.Range(0, length)], spawnPoints[pos++].position, Quaternion.identity).GetComponent<Rigidbody2D>()); 
        for (int i = 0; i < data.trashbagCount; i++) trashBagsList.Add(Instantiate(trashBag, spawnPoints[pos++].position, Quaternion.identity).GetComponent<Rigidbody2D>());
        for (int i = 0; i < data.cardboardCount; i++) cardboardBoxList.Add(Instantiate(cardboardBox,spawnPoints[pos++].position, Quaternion.identity).GetComponent<Rigidbody2D>());
    }

    public void ExitTask()
    {

    }
}
