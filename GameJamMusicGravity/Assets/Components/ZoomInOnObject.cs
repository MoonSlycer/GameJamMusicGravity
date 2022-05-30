using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class ZoomInOnObject : MonoBehaviour
{
    public string tagOfObjectToEnter;

    private GameObject player;
    public float animationDuration = .5f;
    [Range(0.01f, 5f)]
    public float animationZoomAmt = .1f;
    public float durationToWaitAfterAnimation = 0f;

    private bool overlapped = false;
    private Camera m_MainCamera;
    private Vector3 onTouchCameraLoc;
    private float onTouchCameraOrthographicSize;
    private float zoomAnimationCurrentTime = 0;
    private float currentTimeAfterAnimation = 0;

    void Start()
    {
        //This gets the Main Camera from the Scene
        m_MainCamera = Camera.main;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == tagOfObjectToEnter)
        {
            onTouchCameraLoc = m_MainCamera.transform.position;
            onTouchCameraOrthographicSize = m_MainCamera.orthographicSize;

            overlapped = true;
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == tagOfObjectToEnter)
        {
            onTouchCameraLoc = m_MainCamera.transform.position;
            onTouchCameraOrthographicSize = m_MainCamera.orthographicSize;

            overlapped = true;
        }
    }

    public bool changeSceneByNextIndex = false;
    public string newSceneString = "";
    void LateUpdate()
    {
        if (overlapped)
        {
            zoomAnimationCurrentTime += Time.deltaTime;

            float interpolationRatio = (float)(zoomAnimationCurrentTime / animationDuration);
            interpolationRatio = Mathf.Pow(interpolationRatio, 2);
            m_MainCamera.transform.position = Vector3.Lerp(onTouchCameraLoc, gameObject.transform.position, interpolationRatio);
            m_MainCamera.transform.position = new Vector3(m_MainCamera.transform.position.x, m_MainCamera.transform.position.y, -1); // ensure the camera doesn't clip through the objects (dont interpolate the z)
            m_MainCamera.orthographicSize = Mathf.Lerp(onTouchCameraOrthographicSize, animationZoomAmt, interpolationRatio);

            if (zoomAnimationCurrentTime < animationDuration)  //  if the animation isn't finished yet
            {

            }
            else
            {
                Debug.Log("FinishedZooming!");

                currentTimeAfterAnimation += Time.deltaTime;
                if (currentTimeAfterAnimation > durationToWaitAfterAnimation)
                {
                    if (changeSceneByNextIndex)
                    {
                        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
                        SceneManager.LoadScene(currentSceneIndex + 1, LoadSceneMode.Single);
                    }
                    else
                    {
                        SceneManager.LoadScene(newSceneString, LoadSceneMode.Single);
                    }
                }
            }
        }
    }
}
