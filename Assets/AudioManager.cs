using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{

    public AudioMixer audioMixer;
    public AudioMixer audioMixer2;

    private void Start()
    {

    }
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);

    }
    public void SetVolume2(float volume)
    {
        audioMixer2.SetFloat("Volume", volume);
    }

   
}
