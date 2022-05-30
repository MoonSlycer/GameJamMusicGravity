using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D other)
    {
        GameObject[] instruments = GameObject.FindGameObjectsWithTag("Instrument");

        if(other.gameObject.tag == "Player")
        {
            Destroy(other.gameObject);

            InstrumentSpawner.ResetInstrumentTracking();

            GameObject gameMusic = GameObject.FindGameObjectWithTag("MusicPlayer");
            Destroy(gameMusic);

            foreach (GameObject instrument in instruments)
            {
                Rigidbody2D rigidbody = instrument.GetComponent<Rigidbody2D>();

                Vector2 randomDir = (new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f))).normalized;
                rigidbody.AddForce(randomDir * 1000f);
            }
        }




        //GameMusic gameMusicScript = gameMusic.GetComponent<GameMusic>();

        //gameMusicScript.StopAllTracks();
    }
}
