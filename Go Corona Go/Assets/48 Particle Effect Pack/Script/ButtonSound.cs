using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    public AudioClip ButtonClip;
    public AudioSource AudioSR;

    // Start is called before the first frame update
    void Start()
    {
        AudioSR = GetComponent<AudioSource>();
    }

    public void ButtonSoundPlay()
    {
        AudioSR.PlayOneShot(ButtonClip);
    }

   
}
