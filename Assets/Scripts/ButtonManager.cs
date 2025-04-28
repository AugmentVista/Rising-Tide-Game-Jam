using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [Header("UI Screens")]
    public GameObject Options;
    public GameObject Menu;
    public GameObject Gameplay;
    public GameObject Pause;
    public GameObject Credits;

    private GameObject LastScreenActive;

    // Add Last Screen Active Logic
    // Add Last Screen Active Logic
    // Add Last Screen Active Logic
    // Add Last Screen Active Logic
    // Add Last Screen Active Logic
    // Add Last Screen Active Logic
    // Add Last Screen Active Logic
    // Add Last Screen Active Logic
    // Add Last Screen Active Logic
    // Add Last Screen Active Logic
    // Add Last Screen Active Logic

    // Add Last Screen Active Logic
    // Add Last Screen Active Logic
    // Add Last Screen Active Logic
    // Add Last Screen Active Logic
    // Add Last Screen Active Logic
    // Add Last Screen Active Logic
    // Add Last Screen Active Logic
    // Add Last Screen Active Logic
    // Add Last Screen Active Logic
    // Add Last Screen Active Logic
    // Add Last Screen Active Logic
    // Add Last Screen Active Logic



    [Header("Options Volume Sliders")]
    public Slider GameplayVolume;
    public Slider MusicVolume;

    private void Start()
    {
        SetUIFalse();

        Menu.gameObject.SetActive(true);

        Time.timeScale = 0;
    }

    public void SetUIFalse()
    {
        Options.gameObject.SetActive(false);
        Menu.gameObject.SetActive(false);
        Gameplay.gameObject.SetActive(false);
        Pause.gameObject.SetActive(false);
        Credits.gameObject.SetActive(false);
    }

    // All Buttons start with B to make them easier to find in unity

    public void BStarting()
    {
        SetUIFalse();

        Gameplay.gameObject.SetActive(true);

        Time.timeScale = 1;
    }

    public void BQuiting()
    {
        Application.Quit();
    }

    public void BOptionsMenu()
    {
        SetUIFalse();

        Options.gameObject.SetActive(true);
    }

    public void BCreditsMenu()
    {
        SetUIFalse();

        Credits.gameObject.SetActive(true);
    }
}