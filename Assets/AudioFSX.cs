using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFSX : MonoBehaviour
{
    public AudioClip impacto;


    AudioSource audioPlayer;
    // Start is called before the first frame update
    void Start()
    {
        audioPlayer = GetComponent<AudioSource>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayImpacto()
    {
        audioPlayer.PlayOneShot(impacto);
    }
}
