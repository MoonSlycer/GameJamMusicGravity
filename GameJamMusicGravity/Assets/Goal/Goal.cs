using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    private Vector3 onTouchCameraLoc;
    public GameObject player;
    float zoomAnimationCurrentTime = 0;
    public float zoomAnimationDuration = .5f;
    public bool enteredBlackhole = false;
    Camera m_MainCamera;
    private float onTouchCameraOrthographicSize;
    private float animationZoomAmt = .1f;

    void Start()
    {
        //This gets the Main Camera from the Scene
        m_MainCamera = Camera.main;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            onTouchCameraLoc = m_MainCamera.transform.position;
            onTouchCameraOrthographicSize = m_MainCamera.orthographicSize;
            enteredBlackhole = true;
        }
    }



    void LateUpdate()
    {
        if (enteredBlackhole)  // if character touched the black hole
        {
            if (zoomAnimationCurrentTime < zoomAnimationDuration)  //  if the animation isn't finished yet
            {
                zoomAnimationCurrentTime += Time.deltaTime;

                float interpolationRatio = (float)(zoomAnimationCurrentTime / zoomAnimationDuration);
                interpolationRatio = Mathf.Pow(interpolationRatio, 2);
                m_MainCamera.transform.position = Vector3.Lerp(onTouchCameraLoc, gameObject.transform.position, interpolationRatio);
                m_MainCamera.orthographicSize = Mathf.Lerp(onTouchCameraOrthographicSize, animationZoomAmt, interpolationRatio);

            }
            else
            {
                Debug.Log("Goal!");
                // Retrieve the index of the scene in the project's build settings.
                int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
                SceneManager.LoadScene(currentSceneIndex + 1, LoadSceneMode.Single);
            }
        }
    }
}
