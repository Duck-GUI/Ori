using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEditor.Progress;

public class ItemPickup : MonoBehaviour
{
    private PlayerAttack _attack;

    private void Awake()
    {
        _attack = GetComponentInParent<PlayerAttack>();
    }

    public void ItemPickUp()
    {
        if (!_attack.IsCatching)
        {
            Collider[] hits = Physics.OverlapSphere(transform.position, 1f, LayerMask.GetMask("Item"));
            if(hits.Length == 1)
            {
                foreach (var hit in hits.Where(h => Equals(transform.root, h.transform) == false))
                {
                    if (hit.transform.TryGetComponent(out Item item))
                    { 
                        _attack.Damage = item._itemInfo.Damage;
                        item.transform.parent = transform;
                        item.GetComponent<Rigidbody>().isKinematic = true;
                        _attack.IsCatching = true;
                        item.transform.SetLocalPositionAndRotation(item._itemPos,item._itemRot);
                    }
                }
            }
        }
        else
        {
            Transform item = transform.GetChild(0);
            item.transform.SetParent(null);
            item.GetComponent<Rigidbody>().isKinematic = false;
            _attack.Damage = 10;
            _attack.IsCatching = false;
        }
    }
}
