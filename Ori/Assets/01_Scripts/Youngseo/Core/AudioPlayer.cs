using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioPlayer : MonoBehaviour
{
    private AudioSource _audioSource;
    [SerializeField] private float _pitchRandomness, _basePitch;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _basePitch = _audioSource.pitch;
    }

    public void PlayWithBasePitch(AudioClip clip)
    {
        _audioSource.pitch = _basePitch;
        PlayClip(clip);
    }

    public void PlayWithVariablePitch(AudioClip clip)
    {
        float randomPitch = Random.Range(-_pitchRandomness, _pitchRandomness); 
        _audioSource.pitch = _basePitch + randomPitch;
        PlayClip(clip);
    }

    private void PlayClip(AudioClip clip)
    {
        _audioSource.Stop();
        _audioSource.clip = clip;
        _audioSource.Play();
    }
}