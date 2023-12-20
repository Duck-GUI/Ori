using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Rigidbody _rigid;
    private SpringJoint _springJoint;
    private bool _isCatching;

    private static Dictionary<Rigidbody, Rigidbody> _catchMap = new();

    private void Awake()
    {
        var agent = transform.parent;
        _rigid = agent.GetComponent<Rigidbody>();
        _springJoint = agent.GetComponent<SpringJoint>();
    }

    public void Attack()
    {
        var hits = SphereCastAll();

        if (hits is not null && hits.Length > 1)
        {
            foreach (var hit in hits.Where(h => Equals(transform.root, h.transform) == false))
            {
                if (hit.transform.TryGetComponent(out AgentHp agentHp)) agentHp.Damage(transform.position, 10);
            }
        }
    }
    private RaycastHit[] SphereCastAll()
    {
        return Physics.SphereCastAll(transform.position, 0.6f, transform.forward, 0.8f, 1<< 6);
    }
}