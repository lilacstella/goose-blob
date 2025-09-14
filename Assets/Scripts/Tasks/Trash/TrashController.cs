using TMPro;
using UnityEngine;

public class TrashController : MonoBehaviour
{
    public TrashTaskSettings settings;
    [SerializeField] TrashSpawner _trashSpawner;

    public int cardboardBoxCount;
    public int trashBagCount;
    public int smallTrashCount;

    public float velocityThreshold = 1.0f;
    public float checkCompleteInterval = 1.0f;
    private float _checkCompleteInterval = 3.0f;
    private float _countdown = 3f;

    [SerializeField] private CanvasGroup countdownCanvas;
    [SerializeField] private TMP_Text countdownText;

    void Awake()
    {
        // all trash code should rely on this for truth
        // cardboardBoxCount = settings.cardboardBoxLeft;
        // trashBagCount = settings.trashBagLeft;
        // smallTrashCount = settings.smallTrashCount;
        cardboardBoxCount = settings.cardboardCount;
        trashBagCount = settings.trashbagCount;
        smallTrashCount = settings.smallTrashCount;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TaskManager.Instance.onDone.AddListener(scream);
        countdownCanvas.alpha = 0f;
    }

    private void Update()
    {
        // if canvas is visible, countdown is occuring
        if (countdownCanvas.alpha == 1f)
        {
            if (IsPlayerInteracting())
            {
                StopCountdown();
                return;
            }
            countdownText.text = _countdown.ToString("F0");
            if (_countdown <= 0f) { TaskManager.Instance.CurrentTask.CompleteTask(); this.enabled = false; }
            _countdown -= Time.deltaTime;
        }


        // 
        // if (_checkCompleteInterval >= 0f) { _checkCompleteInterval -= Time.deltaTime; }
        // else
        // {
        //     _checkCompleteInterval = checkCompleteInterval;
        //     if (countdownCanvas.alpha == 0f) { if (CheckIfTrashIsStable() && AllTrashOffTheFloor && !IsPlayerInteracting()) { StartCountdown(); } }

        // }
    }

    public bool CheckIfTrashIsStable()
    {
        foreach (Rigidbody2D rb in _trashSpawner.smallTrashList) { if (rb.linearVelocity.magnitude > velocityThreshold) { return false; } }
        foreach (Rigidbody2D rb in _trashSpawner.trashBagsList) { if (rb.linearVelocity.magnitude > velocityThreshold) { return false; } }
        foreach (Rigidbody2D rb in _trashSpawner.cardboardBoxList) { if (rb.linearVelocity.magnitude > velocityThreshold) { return false; } }
        return true;
    }

    public bool IsPlayerInteracting()
    {
        foreach (Rigidbody2D rb in _trashSpawner.smallTrashList) { if (rb.GetComponent<Interactable>().Interacting) { return true; } }
        foreach (Rigidbody2D rb in _trashSpawner.trashBagsList) { if (rb.GetComponent<Interactable>().Interacting) { return true; } }
        foreach (Rigidbody2D rb in _trashSpawner.cardboardBoxList) { if (rb.GetComponent<Interactable>().Interacting) { return true; } }
        return false;
    }

    public bool AllTrashOffTheFloor => _trashSpawner.gameObjectsLeftOnFloor.Count == 0;


    private void scream()
    {
        Debug.Log("HELLO");
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

    void ExitTask()
    {

        // update settings to correct amount of stuff left
        settings.cardboardBoxLeft = cardboardBoxCount;
        settings.trashBagLeft = trashBagCount;
        settings.smallTrashLeft = smallTrashCount;
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (_trashSpawner.smallTrashList.Contains(collision.attachedRigidbody)) { Debug.Log("Testing"); }
    }
}
