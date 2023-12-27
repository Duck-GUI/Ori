using System.Linq;
using UnityEngine;
using DG.Tweening;
using Packets;

public class PlayerAttack : MonoBehaviour
{

    public int Damage = 10;
    public bool IsCatching{ get; set; }
    public bool Lightning { get; set; }
    [SerializeField] private float _rotTime = 1.5f;
    [SerializeField] private GameObject _lightning;

    public void Attack()
    {
        var hits = Physics.SphereCastAll(transform.position, 0.6f, transform.forward, 0.8f, 1 << 6);
        //애니메이션 네트웍
        
        if (hits is not null && hits.Length > 1)
        {
            foreach (var hit in hits.Where(h => Equals(transform.root, h.transform) == false))
            {
                if (hit.transform.TryGetComponent(out AgentHp agentHp))
                {
                    if (IsCatching)
                    {
                        Debug.Log(IsCatching);
                        if (Lightning)
                        {
                            Instantiate(_lightning, hit.transform.position, Quaternion.identity);
                        }
                        transform.parent.DORotate(new Vector3(0, 0, 180), _rotTime/2, RotateMode.FastBeyond360).SetEase(Ease.Linear);
                    }

                    PlayerPacket playerData = new PlayerPacket();
                    playerData.playerID = (ushort)GameManager.Instance.PlayerID;
                    playerData.damged = Damage;

                    C_AttackPacket packet = new C_AttackPacket();
                    packet.playerData = playerData;

                    NetworkManager.Instance.Send(packet);
                    
                    agentHp.Damage(transform.position, Damage);
                }
            }
        }
    }
}