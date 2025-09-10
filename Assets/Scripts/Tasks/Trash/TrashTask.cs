using UnityEngine;

public class TrashTask : Task
{
    [SerializeField] Transform collidersAndSprites;
    public Transform[] trashPilePositions;

    public void Awake()
    {
        collidersAndSprites.position = trashPilePositions[Random.Range(0, trashPilePositions.Length)].position;
    }
}
