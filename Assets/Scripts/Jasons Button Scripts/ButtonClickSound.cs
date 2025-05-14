using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClickSound : MonoBehaviour
{
    [Header("Click Sounds & Source")]
    public List<AudioClip> audioClips;
    public AudioClip SaraSound;
    public List<AudioClip> Boatclick;
    public AudioSource GameplaySounds;

    public void BOnClick()
    {
        int rnd = Random.Range(0, audioClips.Count);
        int SaraRND = Random.Range(0, 101);

        if (SaraRND == 7)
        {
            GameplaySounds.Stop();
            GameplaySounds.clip = SaraSound;
            GameplaySounds.Play();
        }

        else
        {
            GameplaySounds.Stop();
            GameplaySounds.clip = audioClips[rnd];
            GameplaySounds.Play();
        }
    }

    public void BBoatButton()
    {
        int rnd = Random.Range(0, Boatclick.Count);
        GameplaySounds.clip = Boatclick[rnd];
        GameplaySounds.Play();
    }
}
