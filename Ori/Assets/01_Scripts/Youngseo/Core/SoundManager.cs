using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioPlayer))]
public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    private AudioPlayer _audio;

    [SerializeField] private List<AudioClip> _audioClips;

    private void Awake()
    {
        _audio = GetComponent<AudioPlayer>();
    }

    public void PlayHitSound()
    {
        _audio.PlayWithVariablePitch(_audioClips[0]);
    }
}