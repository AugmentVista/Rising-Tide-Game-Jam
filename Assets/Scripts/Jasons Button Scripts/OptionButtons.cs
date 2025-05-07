using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptionButtons : MonoBehaviour
{

    [Header("Options Volume Sliders")]
    public Slider GameplayVolume;
    public Slider MusicVolume;

    [Header("Music & Sounds")]
    public AudioSource GameplaySounds;
    public AudioSource MusicSounds;

    [Header("Cursor Texture")]
    public Texture2D cursorTexture;
    public Vector2 ClickLocation; // Where the cursor can interract with the world EX: Top right of Texture v.s. Center.
    public CursorMode cursorMode = CursorMode.Auto;

    // All Buttons start with B to make them easier to find in unity

    private void Start()
    {
        GameplayVolume.onValueChanged.AddListener((v) => { GameplaySounds.volume = v; });

        MusicVolume.onValueChanged.AddListener((v) => { MusicSounds.volume = v; });
    }

    // All buttons Start with B to make them easier to fond in the inspecter.

    public void BChangeCursor()
    {
        Cursor.SetCursor(cursorTexture, ClickLocation, cursorMode);
    }
}
