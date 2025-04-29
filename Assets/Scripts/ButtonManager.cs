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

    private GameObject GetCurrentActiveScreen()
    {
        if (Options.activeSelf) return Options;
        if (Menu.activeSelf) return Menu;
        if (Gameplay.activeSelf) return Gameplay;
        if (Pause.activeSelf) return Pause;
        if (Credits.activeSelf) return Credits;
        return null;
    }

    private void SetScreen(GameObject newScreen)
    {
        if (newScreen == null)
            return;

        // Save the currently active screen before switching
        if (LastScreenActive != null && LastScreenActive != newScreen && LastScreenActive.activeSelf)
        {
            LastScreenActive = GetCurrentActiveScreen();
        }

        SetUIFalse();
        newScreen.SetActive(true);
    }

    // All Buttons start with B to make them easier to find in unity

    public void BStarting()
    {
        LastScreenActive = GetCurrentActiveScreen();

        SetScreen(Gameplay);

        Time.timeScale = 1;
    }

    public void BQuiting()
    {
        Application.Quit();
    }

    public void BOptionsMenu()
    {
        LastScreenActive = GetCurrentActiveScreen();

        SetScreen(Options);

        Time.timeScale = 0;
    }

    public void BCreditsMenu()
    {
        LastScreenActive = GetCurrentActiveScreen();

        SetScreen(Options);

        Time.timeScale = 0;
    }
}