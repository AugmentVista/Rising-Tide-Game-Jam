using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    internal GameObject Options, Menu, Gameplay, Pause, Credits;

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
    }

    public void Starting()
    {
        SetUIFalse();

        Gameplay.gameObject.SetActive(true);

        Time.timeScale = 1;
    }

    public void Quiting()
    {
        Application.Quit();
    }

    public void OptionsMenu()
    {
        SetUIFalse();

        Options.gameObject.SetActive(true);
    }

    public void CreditsMenu()
    {
        SetUIFalse();

        Credits.gameObject.SetActive(true);
    }
}
