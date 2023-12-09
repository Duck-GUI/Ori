using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public void Attack()
    {
        List<RaycastHit> hits = Physics.SphereCastAll(transform.position, 0.6f, transform.forward, 0.8f).ToList();

        if (hits.Count > 1)
        {
            foreach (var hit in hits.Where(h => Equals(transform.root, h.transform) == false))
            {
                if (hit.transform.TryGetComponent(out AgentHp agentHp)) agentHp.Damage(transform.position, 10);
            }
        }
    }
}