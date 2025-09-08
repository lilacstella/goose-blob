using UnityEngine;

public class TrashTask : Task
{
    [SerializeField] Transform collidersAndSprites;
    public Transform[] trashPilePositions;

    public void Awake()
    {
        collidersAndSprites.position = trashPilePositions[Random.Range(0, trashPilePositions.Length)].position;
    }

    public override void CompleteTask()
    {
        base.CompleteTask();
        _col.gameObject.SetActive(true);
    }

    public override void StartTask()
    {
        base.StartTask();
        _col.gameObject.SetActive(false);
    }
}
