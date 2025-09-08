using UnityEngine;

[CreateAssetMenu(fileName = "TrashSettings", menuName = "Scriptable Objects/TrashSettings")]
public class TrashSettings : ScriptableObject
{
    public TrashData trashData;

    public int smallTrashLeft;
    public int cardboardBoxLeft;
    public int trashBagLeft;
}
