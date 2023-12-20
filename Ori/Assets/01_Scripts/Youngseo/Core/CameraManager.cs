using Cinemachine;
using UnityEngine;
using DG.Tweening;

public class CameraManager : MonoBehaviour
{
    public static CameraManager Instance;

    private CinemachineBasicMultiChannelPerlin _bPerlin;
    private Tween _prevTween = null;

    public void Awake()
    {
        Instance ??= this;
        
        var vCam = GetComponent<CinemachineVirtualCamera>();
        _bPerlin = vCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    public void ShakeCam(float time, float power)
    {
        if (_prevTween != null && _prevTween.IsActive())
        {
            _prevTween.Kill();
        }

        _bPerlin.m_AmplitudeGain = power;
        _prevTween = DOTween.To
        (
            () => _bPerlin.m_AmplitudeGain,
            value => _bPerlin.m_AmplitudeGain = value,
            0, 
            time
        );
    }
}
