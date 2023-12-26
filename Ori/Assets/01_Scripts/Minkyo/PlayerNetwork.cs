using System;
using System.Collections;
using System.Collections.Generic;
using Packets;
using UnityEngine;

public class PlayerNetwork : MonoBehaviour
{
    [SerializeField] private float syncDelay = 0.001f;
    [SerializeField] private float syncDistanceErr = 0.1f;
    private float lastSyncTime = 0f;
    private Vector3 lastSyncPosition = Vector3.zero;
    private Vector3 lastSyncRotation = Vector3.zero;
    
    private void LateUpdate()
    {
        if (lastSyncTime + syncDelay > Time.time)
            return;

        if ((lastSyncPosition - transform.position).sqrMagnitude < syncDistanceErr * syncDistanceErr)
            return;
        
        //rotation check???

        PlayerPacket playerData = new PlayerPacket();
        playerData.playerID = (ushort)GameManager.Instance.PlayerID;
        playerData.x = transform.position.x;
        playerData.y = transform.position.y;
        playerData.z = transform.position.z;

        playerData.xAngle = transform.rotation.eulerAngles.x;
        playerData.yAngle = transform.rotation.eulerAngles.y;
        playerData.zAngle = transform.rotation.eulerAngles.z;

        C_MovePacket packet = new C_MovePacket();
        packet.playerData = playerData;

        NetworkManager.Instance.Send(packet);

        lastSyncPosition = transform.position;
        lastSyncRotation = transform.rotation.eulerAngles;
        lastSyncTime = Time.time;
    }
}
