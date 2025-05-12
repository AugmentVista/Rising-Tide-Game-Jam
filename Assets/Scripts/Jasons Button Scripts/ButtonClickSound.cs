using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClickSound : MonoBehaviour
{
    [Header("Click Sounds & Source")]
    public List<AudioClip> audioClips;
    public AudioSource GameplaySounds;

    public void BOnClick()
    {
        int rnd = Random.Range(0, audioClips.Count);
        GameplaySounds.Stop();
        GameplaySounds.clip = audioClips[rnd];
        GameplaySounds.Play();
    }
}
