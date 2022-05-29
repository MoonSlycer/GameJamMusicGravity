using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float cameraDistance = 1f;

    void Awake()
    {

    }

    void LateUpdate()
    {
        Camera.main.transform.position = this.transform.position + new Vector3(0f, 0f, -cameraDistance);
    }
}
