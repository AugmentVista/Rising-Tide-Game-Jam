using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScreenChangingButtons : MonoBehaviour
{
    [Header("UI Screens")]
    public GameObject Options;
    public GameObject Menu;
    public GameObject Gameplay;
    public GameObject Pause;
    public GameObject Credits;
    public GameObject Confirmation;

    private GameObject LastScreenActive;

    private void Start()
    {
        SetUIFalse();

        Menu.gameObject.SetActive(true);

        Time.timeScale = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Gameplay.activeSelf)
        {
            Debug.Log("Pause");
            SetScreen(Pause);
        }

        else if (Input.GetKeyDown(KeyCode.Escape) && Pause.activeSelf)
        {
            SetScreen(Gameplay);
            Debug.Log("Continue");
        }
    }

    public void SetUIFalse()
    {
        Options.gameObject.SetActive(false);
        Menu.gameObject.SetActive(false);
        Gameplay.gameObject.SetActive(false);
        Pause.gameObject.SetActive(false);
        Credits.gameObject.SetActive(false);
        Confirmation.gameObject.SetActive(false);
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

        if (newScreen == Gameplay)
        {
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
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

    public void BCreditsMenu()
    {
        LastScreenActive = GetCurrentActiveScreen();

        SetScreen(Credits);

        Time.timeScale = 0;
    }

    public void BOptionsMenu()
    {
        LastScreenActive = GetCurrentActiveScreen();

        SetScreen(Options);

        Time.timeScale = 0;
    }

    public void BPause()
    {
        LastScreenActive = GetCurrentActiveScreen();

        SetScreen(Pause);

        Time.timeScale = 0;
    }

    public void BReturn()
    {
        SetScreen(LastScreenActive);
    }

    public void BToMainMenu()
    {
        SetScreen(Menu);

        Time.timeScale = 0;
    }

    public void BQuiting()
    {
        Application.Quit();
    }

    public void BResume()
    {
        SetScreen(Gameplay);

        Time.timeScale = 1;
    }

    public void BReset()
    {
        Confirmation.SetActive(true);
    }

    public void BYesReset()
    {
        SceneManager.LoadScene("BoatClicker_0.0.1");
    }

    public void BNoReset()
    {
        Confirmation.SetActive(false);
    }
}
