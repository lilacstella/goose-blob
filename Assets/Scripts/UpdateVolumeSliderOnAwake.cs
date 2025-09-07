using UnityEngine;
using UnityEngine.UI;


public class UpdateVolumeSliderOnAwake : MonoBehaviour
{
    public string volumeName;
    public Slider volumeSlider;

    private void Awake()
    {
        UpdateSliderFromPlayerPrefs();
    }

    public void UpdateSliderFromPlayerPrefs()
    {
        if (volumeName == "") { Debug.LogWarning("Missing key for volume slider"); }
        else { volumeSlider.SetValueWithoutNotify(PlayerPrefs.GetFloat(volumeName)); }
    }
}
