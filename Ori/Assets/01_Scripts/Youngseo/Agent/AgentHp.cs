using UnityEngine;
using UnityEngine.Events;

public class AgentHp : MonoBehaviour
{
    [SerializeField] private int _maxHp = 200;

    public UnityEvent<Vector3> OnDamaged;
    [SerializeField] private GameObject _explosionPrefab;

    private int ReceivedDamage
    {
        get => _receivedDamage;
        set => _receivedDamage = Mathf.Clamp(value, 0, _maxHp);
    }

    private int _receivedDamage;

    private void Start()
    {
        ReceivedDamage = 0;
    }

    public void Damage(Vector3 hitPoint, int value)
    {
        CameraManager.Instance.ShakeCam(0.2f, 3f);
        UIManager.Instance.Fade();
    
        ReceivedDamage += value;
        hitPoint.y -= 0.5f;
        OnDamaged?.Invoke(hitPoint);
        GameObject obj = Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
        obj.transform.position = transform.position + new Vector3(0, transform.up.y * 0.3f, 0);
    }
}