using System.Linq;
using UnityEngine;
using DG.Tweening;

public class PlayerAttack : MonoBehaviour
{
    
    public int Damage { get; set; }
    public bool IsCatching{ get; set; }
    [SerializeField] private float _rotTime;

    public void Attack()
    {
        var hits = Physics.SphereCastAll(transform.position, 0.6f, transform.forward, 0.8f, 1 << 6);

        if (hits is not null && hits.Length > 1)
        {
            foreach (var hit in hits.Where(h => Equals(transform.root, h.transform) == false))
            {
                if (hit.transform.TryGetComponent(out AgentHp agentHp))
                {
                    transform.root.DORotate(new Vector3(0, 90, 0), _rotTime, RotateMode.Fast);
                    agentHp.Damage(transform.position, Damage);
                }
            }
        }
    }
}