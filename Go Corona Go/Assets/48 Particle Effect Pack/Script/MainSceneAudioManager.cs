using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MainSceneAudioManager : MonoBehaviour
{
    private static readonly string BGPref = "BGPref";
    private static readonly string SFXPref = "SFXPref";
    private float BGVolume, SFXVolume;

    public AudioSource BGAudioSR;
    public AudioSource[] SFXAudioSR;



    void Awake()
    {
      
        ContinueSettings();

    }

    private void ContinueSettings()
    {
        BGVolume = PlayerPrefs.GetFloat(BGPref);
        SFXVolume = PlayerPrefs.GetFloat(SFXPref);
        

        BGAudioSR.volume = BGVolume;

        for (int i = 0; i < SFXAudioSR.Length; i++)
        {
            SFXAudioSR[i].volume = SFXVolume;
        }

    }

    public void SaveSoundSettings()
    {
        PlayerPrefs.SetFloat(BGPref, BGVolume);
        PlayerPrefs.SetFloat(SFXPref, SFXVolume);

    }



}
