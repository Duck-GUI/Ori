using System.Linq;
using UnityEngine;
using System.Collections;
using DG.Tweening;
using System;

public class PlayerAttack : MonoBehaviour
{

    public int Damage = 10;
    public bool IsCatching{ get; set; }
    public bool Lightning { get; set; }
    [SerializeField] private GameObject _lightning;
    

    public void Attack()
    {
        var hits = Physics.SphereCastAll(transform.position, 0.6f, transform.forward, 0.8f, 1 << 6);

        if (hits is not null && hits.Length > 1)
        {
            foreach (var hit in hits.Where(h => Equals(transform.root, h.transform) == false))
            {
                if (hit.transform.TryGetComponent(out AgentHp agentHp))
                {
                    if (Lightning)
                    {
                        Instantiate(_lightning, hit.transform.position, Quaternion.identity);
                    }
                    agentHp.Damage(transform.position, Damage);
                }
            }
        }
    }

    
}