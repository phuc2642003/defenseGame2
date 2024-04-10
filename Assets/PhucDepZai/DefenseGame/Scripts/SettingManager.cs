using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingManager : MonoBehaviour
{
    public Slider musicSlider;
    public Slider soundSlider;

    void Start()
    {
        musicSlider.value = AudioController.Instance.musicVol;
        soundSlider.value = AudioController.Instance.soundVol;
    }
    public void MusicChange(float value)
    {
        AudioController.Instance.musicVol = value;
        AudioController.Instance.musicAudioSource.volume = value;
        PlayerPrefs.SetFloat(Const.MusicVolumne_PREF, value);
    }    
    public void SoundChange(float value)
    {
        AudioController.Instance.soundVol = value;
        AudioController.Instance.soundAudioSource.volume = value;
        PlayerPrefs.SetFloat(Const.SoundVolumne_PREF, value);
    }    
}
