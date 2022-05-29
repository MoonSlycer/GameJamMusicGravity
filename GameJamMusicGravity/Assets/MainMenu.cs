using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //Make sure to attach these Buttons in the Inspector
    public Button PlayBtn;
    public Button QuityBtn;

    void Start()
    {
        if (PlayBtn != null)
        {
            PlayBtn.onClick.AddListener(OnPlayPressed);
        }
        if (QuityBtn != null)
        {
            QuityBtn.onClick.AddListener(OnQuitPressed);
        }
    }

    void OnPlayPressed()
    {
        SceneManager.LoadScene("Level1", LoadSceneMode.Single);
    }

    void OnQuitPressed()
    {
        Application.Quit();
    }
}