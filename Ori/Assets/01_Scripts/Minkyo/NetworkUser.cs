using System;
using System.Collections;
using System.Collections.Generic;
using Packets;
using UnityEngine;

public class NetworkUser : MonoBehaviour
{
    private AgentHp _hp;

    private void Awake()
    {
        _hp = GetComponent<AgentHp>();
    }

    public void Hit(PlayerPacket packetData)
    {
        _hp.ReceivedDamage = packetData.damged;
        Debug.Log($"Dam {_hp.ReceivedDamage}");
    }
}
