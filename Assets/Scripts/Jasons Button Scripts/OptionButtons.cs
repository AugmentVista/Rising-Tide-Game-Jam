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
    public Texture2D AncorTexture;
    public Texture2D WheelTexture;
    public Texture2D HatTexture;
    public Texture2D DuckTexture;
    public Texture2D BoatTexture;


    public List<Vector2> ClickLocation; // Where the cursor can interract with the world EX: Top right of Texture v.s. Center.
    public CursorMode cursorMode = CursorMode.Auto;

    // All Buttons start with B to make them easier to find in unity

    private void Start()
    {
        GameplayVolume.onValueChanged.AddListener((v) => { GameplaySounds.volume = v; });

        MusicVolume.onValueChanged.AddListener((v) => { MusicSounds.volume = v; });
    }

    //Find the pixel based off the Vector2 List
    Vector2 NormalizeClickLocation(Vector2 normalized, Texture2D texture)
    {
        float x = Mathf.Round(normalized.x * texture.width);
        float y = Mathf.Round(normalized.y * texture.height);
        return new Vector2(x, y);
    }

    // All buttons Start with B to make them easier to fond in the inspecter.
    // Click Locations are Set in the inspector in order of the public textures.

    public void BAncorTexture()
    {
        Vector2 PixelLocation = NormalizeClickLocation(ClickLocation[0], AncorTexture);
        Cursor.SetCursor(AncorTexture, PixelLocation, cursorMode);
    }

    public void BWheelTexture()
    {
        Vector2 PixelLocation = NormalizeClickLocation(ClickLocation[1], WheelTexture);
        Cursor.SetCursor(WheelTexture, PixelLocation, cursorMode);
    }

    public void BHatTexture()
    {
        Vector2 PixelLocation = NormalizeClickLocation(ClickLocation[2], HatTexture);
        Cursor.SetCursor(HatTexture, PixelLocation, cursorMode);
    }

    public void BDuckTexture()
    {
        Vector2 PixelLocation = NormalizeClickLocation(ClickLocation[3], DuckTexture);
        Cursor.SetCursor(DuckTexture, PixelLocation, cursorMode);
    }

    public void BBoatTexture()
    {
        Vector2 PixelLocation = NormalizeClickLocation(ClickLocation[4], BoatTexture);
        Cursor.SetCursor(BoatTexture, PixelLocation, cursorMode);
    }
}
