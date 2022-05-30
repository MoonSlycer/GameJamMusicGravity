using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    private Vector3 onTouchCameraLoc;
    private GameObject player;
    float zoomAnimationCurrentTime = 0;
    public float zoomAnimationDuration = .5f;
    public bool enteredBlackhole = false;
    Camera m_MainCamera;
    private float onTouchCameraOrthographicSize;
    private float animationZoomAmt = .1f;

    private bool bHasInstrument = false;

    private GameObject messageObject = null;


    void Awake()
    {
        messageObject = transform.Find("Message").gameObject;
    }

    void Start()
    {
        //This gets the Main Camera from the Scene
        m_MainCamera = Camera.main;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == InstrumentSpawner.currentInstrument)
        {
            bHasInstrument = true;
        }

        if (other.gameObject.tag == "Player")
        {
            onTouchCameraLoc = m_MainCamera.transform.position;
            onTouchCameraOrthographicSize = m_MainCamera.orthographicSize;
            enteredBlackhole = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            enteredBlackhole = false;
            messageObject.SetActive(false);
        }

        if (other.gameObject == InstrumentSpawner.currentInstrument)
        {
            bHasInstrument = false;
        }
    }



    void LateUpdate()
    {
        if (enteredBlackhole)  // if character touched the black hole
        {
            if (bHasInstrument || InstrumentSpawner.currentInstrument == null) // if the character has the instrument (or if there is no instrument)
            {
                if (zoomAnimationCurrentTime < zoomAnimationDuration)  //  if the animation isn't finished yet
                {
                    zoomAnimationCurrentTime += Time.deltaTime;

                    float interpolationRatio = (float)(zoomAnimationCurrentTime / zoomAnimationDuration);
                    interpolationRatio = Mathf.Pow(interpolationRatio, 2);
                    Debug.Log(interpolationRatio);
                    m_MainCamera.transform.position = Vector3.Lerp(onTouchCameraLoc, gameObject.transform.position, interpolationRatio);
                    m_MainCamera.transform.position = new Vector3(m_MainCamera.transform.position.x, m_MainCamera.transform.position.y, -1); // ensure the camera doesn't clip through the objects (dont interpolate the z)
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
            else
            {
                messageObject.SetActive(true);
            }
        }
    }
}
