using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour {

    public AudioClip clip;
    public AudioClip clip2;

    public AudioSource source;
    public AudioSource source2;


    // Use this for initialization
    void Start () {
      
       source.clip = clip;
        source2.clip = clip2;
        source.Play();
        source2.Play();
    }

    void PlayAudio(AudioSource src)
    {
        src.Play();
    }
    
}
