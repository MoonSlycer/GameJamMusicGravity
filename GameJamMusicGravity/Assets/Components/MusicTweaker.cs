using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTweaker : MonoBehaviour
{
    public List<AudioClip> clipsToMute = new List<AudioClip>();
    public List<AudioClip> clipsToUnmute = new List<AudioClip>();

    void Start()
    {
        // Mute/unmute the MusicPlayer's AudioSources
        GameObject musicPlayer = GameObject.FindWithTag("MusicPlayer");
        AudioSource[] audioSources = musicPlayer.GetComponents<AudioSource>();
        foreach (AudioSource audioSource in audioSources)
        {
            if (clipsToMute.Contains(audioSource.clip))
            {
                audioSource.mute = true;
            }

            if (clipsToUnmute.Contains(audioSource.clip))
            {
                audioSource.mute = false;
            }
        }
    }
}
