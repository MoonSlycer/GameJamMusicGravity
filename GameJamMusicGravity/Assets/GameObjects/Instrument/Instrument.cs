using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instrument : MonoBehaviour
{
    /** Instrument crashing sound effect */
    public AudioClip crashAudioClip;

    // Cached reference to our audio source to play through
    private AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        audioSource.PlayOneShot(crashAudioClip, 0.1f);
    }
}
