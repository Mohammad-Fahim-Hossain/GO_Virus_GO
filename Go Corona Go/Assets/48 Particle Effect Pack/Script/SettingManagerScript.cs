using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingManagerScript : MonoBehaviour
{
    public GameObject ManuButtons;
    public GameObject SettingsPanel;
    public GameObject SettingButton;
    public GameObject Nametext;
    public GameObject SpriteImage1;
    public GameObject SpriteImage2;
    public GameObject SpriteImage3;

    private void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    public void OpenSettings()
    {
        Nametext.SetActive(false);
        SettingButton.SetActive(false);
        ManuButtons.SetActive(false);
        SpriteImage1.SetActive(false);
        SpriteImage2.SetActive(false);
        SpriteImage3.SetActive(false);

        SettingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        Nametext.SetActive(true);
        SettingButton.SetActive(true);
        ManuButtons.SetActive(true);
        SpriteImage1.SetActive(true);
        SpriteImage2.SetActive(true);
        SpriteImage3.SetActive(true);

        SettingsPanel.SetActive(false);
    }


 
    
}
