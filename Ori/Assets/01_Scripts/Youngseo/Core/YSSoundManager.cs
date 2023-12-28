using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioPlayer))]
public class YSSoundManager : MonoBehaviour
{
    public static YSSoundManager Instance;
    private AudioPlayer _audio;

    [SerializeField] private List<AudioClip> _audioClips;

    public void Init()
    {
        _audio = GetComponent<AudioPlayer>();
    }

    public void PlayHitSound()
    {
        _audio.PlayWithVariablePitch(_audioClips[0]);
    }
}