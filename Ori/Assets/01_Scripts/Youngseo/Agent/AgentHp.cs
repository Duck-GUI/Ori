using Packets;
using UnityEngine;
using UnityEngine.Events;

public class AgentHp : MonoBehaviour
{
    [SerializeField] private int _maxHp = 200;

    public UnityEvent<Vector3> OnDamaged;
    [SerializeField] private GameObject _explosionPrefab;

    public int ReceivedDamage
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
        ReceivedDamage += value;
        
        CameraManager.Instance.ShakeCam(0.2f, 3f);
        UIManager.Instance.Fade();

        PlayerPacket playerData = new PlayerPacket();
        playerData.playerID = GetComponent<OtherPlayer>().otherId;
        playerData.damged = ReceivedDamage;

        C_HitPacket packet = new C_HitPacket();
        packet.playerData = playerData;

        NetworkManager.Instance.Send(packet);
        
        CameraManager.Instance.ShakeCam(0.2f, 3f);
        hitPoint.y -= 0.5f;
        OnDamaged?.Invoke(hitPoint);
        GameObject obj = Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
        obj.transform.position = transform.position + new Vector3(0, transform.up.y * 0.3f, 0);
    }
}