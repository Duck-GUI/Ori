using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    private Image _image;
    
    private Tween _prevTween;
    private Material _bloodMat;
    private readonly int _dissolveValueHash = Shader.PropertyToID("_DissolveValue");

    public void Init(Transform canvasTrm)
    {
        _image =  canvasTrm.Find("Image").GetComponent<Image>();
        _bloodMat = _image.material;
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