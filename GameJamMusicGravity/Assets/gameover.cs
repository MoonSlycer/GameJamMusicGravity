using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameover : MonoBehaviour
{
    //Make sure to attach these Buttons in the Inspector
    public Button TryAgainBtn;

    void Start()
    {
        if (TryAgainBtn != null)
        {
            TryAgainBtn.onClick.AddListener(OnTryAgainPressed);
        }
    }

    void OnTryAgainPressed()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}
