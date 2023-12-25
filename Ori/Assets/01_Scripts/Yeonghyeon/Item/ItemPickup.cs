using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    private PlayerAttack _attack;
    private bool _isCatching = false;

    private void Awake()
    {
        _attack = GetComponentInParent<PlayerAttack>();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 2f);
    }

    public void ItemPickUp()
    {
        var hits = Physics.SphereCastAll(transform.position, 0.3f, Vector3.up, 0, LayerMask.GetMask("Item"));

        if(hits is not null && && !_isCatching)
        {
            foreach (var hit in hits.Where(h => Equals(transform.root, h.transform) == false))
            {
                if (hit.transform.TryGetComponent(out Item item))
                {
                    _attack.Damage = item._itemInfo.Damage;
                    item.transform.parent = transform;
                    item.GetComponent<Rigidbody>().useGravity = false;
                    _isCatching = true;
                }
            }
        }
    }

    public void ItemPickDown()
    {
        if( _isCatching)
        {
            GameObject item = transform.GetComponentInChildren<GameObject>();
            item.transform.parent = null;
            item.GetComponent<Rigidbody>().useGravity = true;
            _isCatching = false;
        }
    }
}
