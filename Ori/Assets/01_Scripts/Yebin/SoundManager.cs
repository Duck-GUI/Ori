using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource musicSource;

    public AudioSource btnSource;
    public void SetMusicVolume(float volume)
    {
        musicSource.volume = volume;
    }
    public void SetButtonVolume(float volume)
    {
        btnSource.volume = volume;
    }

    public void OnSfx()
    {
        btnSource.Play();
    }
}
