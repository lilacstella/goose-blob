using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsController : MonoBehaviour
{
    public AudioMixer audioMixer;

    private void Start()
    {
        SetDefaultAudioSettings();
    }

    public static void SetDefaultAudioSettings()
    {
        if (!PlayerPrefs.HasKey(AudioCategory.Master.ToString())) { PlayerPrefs.SetFloat(AudioCategory.Master.ToString(), 100f); }
        if (!PlayerPrefs.HasKey(AudioCategory.Music.ToString())) { PlayerPrefs.SetFloat(AudioCategory.Music.ToString(), 50f); }
        if (!PlayerPrefs.HasKey(AudioCategory.GUI.ToString())) { PlayerPrefs.SetFloat(AudioCategory.GUI.ToString(), 75f); }
        if (!PlayerPrefs.HasKey(AudioCategory.SFX.ToString())) { PlayerPrefs.SetFloat(AudioCategory.SFX.ToString(), 75f); }
        PlayerPrefs.Save();
    }
    
    public void ResetDefaultAudioSettings()
    {
        PlayerPrefs.DeleteKey(AudioCategory.Master.ToString());
        PlayerPrefs.DeleteKey(AudioCategory.Music.ToString());
        PlayerPrefs.DeleteKey(AudioCategory.GUI.ToString());
        PlayerPrefs.DeleteKey(AudioCategory.SFX.ToString());

        SetDefaultAudioSettings();
        FindAndUpdateAllAudioSliders();
    }

    private static void FindAndUpdateAllAudioSliders()
    {
        Object[] sliders = Resources.FindObjectsOfTypeAll(typeof(UpdateVolumeSliderOnAwake));
        for (int i = 0; i < sliders.Length; i++)
        {
            sliders[i].GetComponent<UpdateVolumeSliderOnAwake>().UpdateSliderFromPlayerPrefs();
        }
    }

    public void UpdateMasterVolume(float volume)
    {
        SetVolume(volume, AudioCategory.Master, true);
    }
    public void UpdateMusicVolume(float volume)
    {
        SetVolume(volume, AudioCategory.Music, true);
    }
    public void UpdateGUIVolume(float volume)
    {
        SetVolume(volume, AudioCategory.GUI, true);
    }
    public void UpdateSFXVolume(float volume)
    {
        SetVolume(volume, AudioCategory.SFX, true);
    }

    private void SetVolume(float volume, AudioCategory name, bool saveValue = false)
    {
        audioMixer.SetFloat(name.ToString(), ConvertVolumeToDecibels(volume));
        if (saveValue) { PlayerPrefs.SetFloat(name.ToString(), volume); PlayerPrefs.Save(); }
    }

    public static float ConvertVolumeToDecibels(float volume) => Mathf.Log10(volume) * 20 - 40f;

    public enum AudioCategory
    {
        Master,
        Music,
        GUI,
        SFX,
    }
}
