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
    public float velocityThreshold = 1.0f;
    public float checkCompleteInterval = 1.0f;
    private float _checkCompleteInterval = 3.0f;
    private float _countdown = 3f;

    [SerializeField] private CanvasGroup countdownCanvas;
    [SerializeField] private TMP_Text countdownText;

    public TrashTaskSettings settings;

    public Transform[] spawnPoints;

    private void Start()
    {
        if(TaskManager.Instance != null) settings = (TrashTaskSettings)TaskManager.Instance.CurrentTask.settings;
        if (settings != null)
        {
            SpawnTrash();
        }
        countdownCanvas.alpha = 0f;
    }

    private void Update()
    {
        if (countdownCanvas.alpha == 1f) 
        {
            if (IsPlayerInteracting()) { StopCountdown(); return; }
            countdownText.text = _countdown.ToString("F1");
            if (_countdown <= 0f) { TaskManager.Instance.CurrentTask.CompleteTask(); this.enabled = false; }
            _countdown -= Time.deltaTime;
        }


        if (_checkCompleteInterval >= 0f) { _checkCompleteInterval -= Time.deltaTime; }
        else { _checkCompleteInterval = checkCompleteInterval;
            if (countdownCanvas.alpha == 0f) { if (CheckIfTrashIsStable() && AllTrashOffTheFloor && !IsPlayerInteracting()) { StartCountdown(); } }
            
        }
    }

    private void StartCountdown()
    {
        countdownCanvas.alpha = 1f;
        _countdown = 3f;
    }

    public void StopCountdown()
    {
        countdownCanvas.alpha = 0f;
        _countdown = 3f;
    }

    public bool CheckIfTrashIsStable()
    {
        foreach (Rigidbody2D rb in smallTrashList) { if (rb.linearVelocity.magnitude > velocityThreshold) { return false; } }
        foreach (Rigidbody2D rb in trashBagsList) { if (rb.linearVelocity.magnitude > velocityThreshold) { return false; } }
        foreach (Rigidbody2D rb in cardboardBoxList) { if (rb.linearVelocity.magnitude > velocityThreshold) { return false; } }
        return true;
    }

    public bool IsPlayerInteracting()
    {
        foreach (Rigidbody2D rb in smallTrashList) { if (rb.GetComponent<Interactable>().Interacting) { return true; } }
        foreach (Rigidbody2D rb in trashBagsList) { if (rb.GetComponent<Interactable>().Interacting) { return true; } }
        foreach (Rigidbody2D rb in cardboardBoxList) { if (rb.GetComponent<Interactable>().Interacting) { return true; } }
        return false;
    }

    public bool AllTrashOffTheFloor => gameObjectsLeftOnFloor.Count == 0;

    void SpawnTrash()
    {
        int pos = 0;
        for (int i = 0; i < settings.smallTrashCount; i++)
        {
            int rand = Random.Range(0, smallTrashObjects.Length);
            GameObject gameObject = Instantiate(smallTrashObjects[rand], spawnPoints[pos++].position, Quaternion.identity);
            gameObject.GetComponent<Collider2D>().enabled = false;
            smallTrashList.Add(gameObject.GetComponent<Rigidbody2D>());
        }
        for (int i = 0; i < settings.trashbagCount; i++)
        {
            GameObject gameObject = Instantiate(trashBag, spawnPoints[pos++].position, Quaternion.identity);
            gameObject.GetComponent<Collider2D>().enabled = false;
            float scale = Random.Range(0.8f, 1.3f);
            gameObject.transform.localScale = Vector3.one * scale;
            trashBagsList.Add(gameObject.GetComponent<Rigidbody2D>());

        }
        for (int i = 0; i < settings.cardboardCount; i++)
        {
            GameObject gameObject = Instantiate(cardboardBox, spawnPoints[pos++].position, Quaternion.identity);
            gameObject.GetComponent<Collider2D>().enabled = false;
            float scale = Random.Range(1.5f, 2.58f);
            gameObject.transform.localScale = new Vector3(scale, 1f, 1f);
            cardboardBoxList.Add(gameObject.GetComponent<Rigidbody2D>());
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
