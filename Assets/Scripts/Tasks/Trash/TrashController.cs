using UnityEngine;

public class TrashController : MonoBehaviour
{
    public TrashTaskSettings settings;

    public int cardboardBoxCount;
    public int trashBagCount;
    public int smallTrashCount;

    void Awake()
    {
        // all trash code should rely on this for truth
        // cardboardBoxCount = settings.cardboardBoxLeft;
        // trashBagCount = settings.trashBagLeft;
        // smallTrashCount = settings.smallTrashCount;
        cardboardBoxCount = 2;
        trashBagCount = 2;
        smallTrashCount = 2;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void ExitTask()
    {

        // update settings to correct amount of stuff left
        settings.cardboardBoxLeft = cardboardBoxCount;
        settings.trashBagLeft = trashBagCount;
        settings.smallTrashLeft = smallTrashCount;
    }
}
