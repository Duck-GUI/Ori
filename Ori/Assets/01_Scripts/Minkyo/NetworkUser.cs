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
        Vector3 dir = new Vector3(packetData.xHit, packetData.yHit, packetData.zHit);
        Debug.Log(dir);
        _hp.ReceivedDamage = packetData.damged;
        _hp.AAA(dir);
    }
}
