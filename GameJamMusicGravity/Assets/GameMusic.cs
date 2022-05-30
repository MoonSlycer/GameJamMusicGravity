using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMusic : MonoBehaviour
{
    void Start()
    {
        GameObject[] musicObjs = GameObject.FindGameObjectsWithTag("MusicPlayer");
        if (musicObjs.Length > 1)
        {
            foreach (var item in musicObjs)
            {
                if (item != this.gameObject)
                {
                    Destroy(item);
                }
            }
        }
    }

    public void StopAllTracks()
    {
        AudioSource[] audioSources = GetComponents<AudioSource>();
        foreach (AudioSource source in audioSources)
        {
            source.enabled = false;
        }
    }
}
