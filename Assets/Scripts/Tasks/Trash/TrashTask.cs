using UnityEngine;

public class TrashTask : Task
{
    [SerializeField] Transform collidersAndSprites;
    public Transform[] trashPilePositions;

    public int smallTrashCount = 1;
    public int cardboardCount = 0;
    public int trashbagCount = 0;
    public void Awake()
    {
        collidersAndSprites.position = trashPilePositions[Random.Range(0, trashPilePositions.Length)].position;
    }
}
