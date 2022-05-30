using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstrumentSpawner : MonoBehaviour
{
    /** List of random instruments to spawn */
    public List<GameObject> instrumentPrefabs;

    /** Static reference to the current instrument */
    static public GameObject currentInstrument = null;

    // Used to keep track of what we have already spawned
    static private List<GameObject> usedPrefabs = new List<GameObject>();

    public void Start()
    {
        SpawnRandomInstrument();
    }

    public void SpawnRandomInstrument()
    {
        // Fill out our available prefabs to spawn
        List<GameObject> availablePrefabs = new List<GameObject>();
        for (int i = 0; i < instrumentPrefabs.Count; ++i)
        {
            if (usedPrefabs.Contains(instrumentPrefabs[i]))
            {
                continue;
            }

            availablePrefabs.Add(instrumentPrefabs[i]);
        }

        // Spawn a random prefab
        if (availablePrefabs.Count > 0)
        {
            GameObject randomPrefab = availablePrefabs[Random.Range(0, availablePrefabs.Count)];
            usedPrefabs.Add(randomPrefab);

            currentInstrument = Instantiate(randomPrefab, transform.position, Quaternion.identity);
        }
    }
}
