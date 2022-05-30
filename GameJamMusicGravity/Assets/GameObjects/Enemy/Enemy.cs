using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Destroy(other.gameObject);

            GameObject gameMusic = GameObject.FindGameObjectWithTag("MusicPlayer");
            Destroy(gameMusic);
        }




        //GameMusic gameMusicScript = gameMusic.GetComponent<GameMusic>();

        //gameMusicScript.StopAllTracks();
    }
}
