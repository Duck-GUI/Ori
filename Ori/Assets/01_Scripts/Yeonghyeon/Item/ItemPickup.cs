using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
   private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 2f);
    }

    private void ItemPick()
    {
        RaycastHit[] hits = Physics.SphereCastAll(transform.position, 0.3f, Vector3.up, 0, LayerMask.GetMask("Player"));

    }
}
