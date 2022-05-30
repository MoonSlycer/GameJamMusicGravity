using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistantGameObject : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
