using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class BloodScreen : MonoBehaviour
{
    private Material _bloodMat;
    private readonly int _dissolveValueHash = Shader.PropertyToID("_DissolveValue");

    private Tween _prevTween;

    private void Awake()
    {
        _bloodMat = GetComponent<Image>().material;
    }

    private void Start()
    {
        _bloodMat.SetFloat(_dissolveValueHash, 0);
    }

    public void Fade()  
    {
        if (_prevTween is not null && _prevTween.IsActive())
        {
            _prevTween.Kill();
        }
        
        _bloodMat.SetFloat(_dissolveValueHash, 0);
        _prevTween = DOTween.To
        (
            () => _bloodMat.GetFloat(_dissolveValueHash),
            value => _bloodMat.SetFloat(_dissolveValueHash, value),
            1,
            0.2f
        ).SetEase(Ease.OutCirc).OnComplete(() => 
            _prevTween = DOTween.To
            (
                () => _bloodMat.GetFloat(_dissolveValueHash),
                value => _bloodMat.SetFloat(_dissolveValueHash, value),
                0,
                1f 
            ).SetEase(Ease.InSine));
    }
}