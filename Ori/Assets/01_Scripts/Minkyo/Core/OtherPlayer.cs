using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Packets;

public class OtherPlayer : MonoBehaviour
{
    public void SetPosition(PlayerPacket playerData)
    {
        Vector3 pos = transform.position;
        pos.x = playerData.x;
        pos.y = playerData.y;
        pos.z = playerData.z;

        Vector3 anglePos = transform.rotation.eulerAngles;
        anglePos.x = playerData.xAngle;
        anglePos.y = playerData.yAngle;
        anglePos.z = playerData.zAngle;

        Debug.Log($"PlayerData X : {playerData.xAngle}");

        Debug.Log($"AnglePos X : {anglePos.x}");

        transform.position = pos;
        transform.rotation = Quaternion.Euler(anglePos.x, anglePos.y, anglePos.z);
    }
}
