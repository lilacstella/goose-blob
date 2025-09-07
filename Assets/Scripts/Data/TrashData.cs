using UnityEngine;

[CreateAssetMenu(fileName = "TrashData", menuName = "Tasks/TrashData")]
public class TrashData : ScriptableObject
{
    public int smallTrashCount = 1;
    public int cardboardCount = 0;
    public int trashbagCount = 0;
}
