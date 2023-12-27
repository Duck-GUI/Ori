using Packets;
using UnityEngine;
using UnityEngine.Events;

public class AgentHp : MonoBehaviour
{
    [SerializeField] private int _maxHp = 200;

    public UnityEvent<Vector3> OnDamaged;
    private OtherPlayer _other;

    public int ReceivedDamage
    {
        get => _receivedDamage;
        set => _receivedDamage = Mathf.Clamp(value, 0, _maxHp);
    }

    [SerializeField] private int _receivedDamage;

    private void Start()
    {
        ReceivedDamage = 0;
    }

    public void Damage(Vector3 hitPoint, int value)
    {
        ReceivedDamage += value;
        
        CameraManager.Instance.ShakeCam(0.2f, 3f);
        //수정
        //UIManager.Instance.Fade();
        
        if (TryGetComponent(out _other))
        {
            PlayerPacket playerData = new PlayerPacket();
            playerData.playerID = (ushort)GameManager.Instance.PlayerID;
            playerData.ohterID = _other.OtherID;
            playerData.damged = ReceivedDamage;

            playerData.x = hitPoint.x;
            playerData.y = hitPoint.y;
            playerData.z = hitPoint.z;

            C_HitPacket packet = new C_HitPacket();
            packet.playerData = playerData;

            NetworkManager.Instance.Send(packet);
        }
        
        CameraManager.Instance.ShakeCam(0.2f, 3f);
        hitPoint.y -= 0.5f;
        OnDamaged?.Invoke(hitPoint);
        YSSoundManager.Instance.PlayHitSound();
        Explosion obj = PoolManager.Instance.Pop("Explosion") as Explosion;
        obj.transform.position = transform.position + new Vector3(0, transform.up.y * 0.3f, 0);
    }

    public void AAA(Vector3 hitPoint)
    {
        CameraManager.Instance.ShakeCam(0.2f, 3f);
        hitPoint.y -= 0.5f;
        OnDamaged?.Invoke(hitPoint);
        Explosion obj = PoolManager.Instance.Pop("Explosion") as Explosion;
        obj.transform.position = transform.position + new Vector3(0, transform.up.y * 0.3f, 0);
    }
}