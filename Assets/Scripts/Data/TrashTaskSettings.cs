using NUnit.Framework;
using UnityEngine;

[CreateAssetMenu(fileName = "Trash Settings", menuName = "Tasks/Trash/Settings")]
public class TrashTaskSettings: TaskSettings
{
    public int smallTrashCount = 1;
    public int cardboardCount = 0;
    public int trashbagCount = 0;

    public int smallTrashLeft;
    public int cardboardBoxLeft;
    public int trashBagLeft;
}
