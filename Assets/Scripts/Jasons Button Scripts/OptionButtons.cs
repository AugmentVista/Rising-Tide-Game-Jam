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

    // All Buttons start with B to make them easier to find in unity

    private void Start()
    {
        GameplayVolume.onValueChanged.AddListener((v) => { GameplaySounds.volume = v; });

        MusicVolume.onValueChanged.AddListener((v) => { MusicSounds.volume = v; });
    }

    public void PixaBayCardoard()
    {
        Application.OpenURL("https://pixabay.com/photos/parcel-post-deliver-moving-4967721/");
    }
}
