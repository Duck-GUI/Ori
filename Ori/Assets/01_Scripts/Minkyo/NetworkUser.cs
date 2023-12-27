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
        Debug.Log("형형형형형형형형형형");
        _hp.ReceivedDamage = packetData.damged;
        Debug.Log($"Dam {_hp.ReceivedDamage}");
        _hp.AAA();
    }
}
