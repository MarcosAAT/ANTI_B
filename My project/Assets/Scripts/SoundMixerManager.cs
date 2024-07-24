using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundMixerManager : MonoBehaviour


{
[SerializeField] private AudioMixer audioMixer;
[SerializeField] private Slider musicSlider;
[SerializeField] private Slider sfxSlider;

private void Start()
{
    if (PlayerPrefs.HasKey("mxVolume"))
    {
        LoadVolume();
    }
    else
    {
        SetMusicVolume();
        SetSoundFXVolume();
    }
   
}



public void SetSoundFXVolume()
{
float volume = sfxSlider.value;
audioMixer.SetFloat("sfxVolume", Mathf.Log10(volume)*20);
PlayerPrefs.SetFloat("soundVolume", volume);
}

public void SetMusicVolume()
{
float volume = musicSlider.value;
audioMixer.SetFloat("musicVolume", Mathf.Log10(volume)*20);
PlayerPrefs.SetFloat("mxVolume", volume);
}

private void LoadVolume()
{
    musicSlider.value = PlayerPrefs.GetFloat("mxVolume");
    sfxSlider.value = PlayerPrefs.GetFloat("soundVolume");

   

    SetMusicVolume();
    SetSoundFXVolume();
}

}

