using UnityEngine;

[CreateAssetMenu(fileName = "Guilt Settings", menuName = "Tasks/Guilt Settings")]
public class GuiltSettings : ScriptableObject
{
    public int guiltPerFail = 5;
    public int guiltPerCompletion = 10;
}
