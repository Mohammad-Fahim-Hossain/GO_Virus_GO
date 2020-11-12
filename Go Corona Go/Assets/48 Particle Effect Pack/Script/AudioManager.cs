using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    private static readonly string FirstPlay = "FirstPlay";
    private static readonly string BGPref = "BGPref";
    private static readonly string SFXPref = "SFXPref";
    private int FirstPlayInt;

    public Slider BGSlider, SFXSlider;
    private float BGVolume, SFXVolume;

    public AudioSource BGAudioSR;
    public AudioSource[] SFXAudioSR;


    // Start is called before the first frame update
    void Start()
    {
        FirstPlayInt = PlayerPrefs.GetInt(FirstPlay);

        if (FirstPlayInt == 0)
        {
            BGVolume = 0.50f;
            SFXVolume = 1f;

            BGSlider.value = BGVolume;
            SFXSlider.value = SFXVolume;

            PlayerPrefs.SetFloat(BGPref, BGVolume);
            PlayerPrefs.SetFloat(SFXPref, SFXVolume);
            PlayerPrefs.SetFloat(FirstPlay, -1);
        }
        else
        {
            BGVolume = PlayerPrefs.GetFloat(BGPref);
            SFXVolume = PlayerPrefs.GetFloat(SFXPref);

            BGSlider.value = BGVolume;
            SFXSlider.value = SFXVolume;
        }

        
    }

    public void SaveSoundSettings()
    {
        PlayerPrefs.SetFloat(BGPref, BGSlider.value);
        PlayerPrefs.SetFloat(SFXPref, SFXSlider.value);

    }

    private void OnApplicationFocus(bool focus)
    {
        if (!focus)
        {
            SaveSoundSettings();
        }
    }


    public void UpdateSound()
    {
        BGAudioSR.volume = BGSlider.value;

        for(int i=0; i < SFXAudioSR.Length; i++){
            SFXAudioSR[i].volume = SFXSlider.value;
        }
    }
}
