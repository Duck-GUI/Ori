using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Item : MonoBehaviour
{
    private Collider _col;
    [SerializeField] private ItemSO _itemInfo;

    private void Awake()
    {
        _col = GetComponent<Collider>();
    }
    public void ItemAttack()
    {
        var hits = SphereCastAll();

        if (hits is not null && hits.Length > 1)
        {
            foreach (var hit in hits.Where(h => Equals(transform.root, h.transform) == false))
            {
                if (hit.transform.TryGetComponent(out AgentHp agentHp)) agentHp.Damage(transform.position, _itemInfo.Damage);
            }
        }
    }

   


    

    private RaycastHit[] SphereCastAll()
    {
        return Physics.SphereCastAll(transform.position, 0.6f, transform.forward, 1f, 1 << 6);
    }
}
