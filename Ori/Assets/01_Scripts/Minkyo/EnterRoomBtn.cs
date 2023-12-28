using System.Collections;
using System.Collections.Generic;
using HelloNetwork;
using Packets;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterRoomBtn : MonoBehaviour
{
    public void EnterRoom()
    {
        if(GameManager.Instance.PlayerID < 0)
            return;

        C_RoomEnterPacket packet = new C_RoomEnterPacket();
        packet.playerID = (ushort)GameManager.Instance.PlayerID;
        
        NetworkManager.Instance.Send(packet);
    }

    public void Ch()
    {
        SceneManager.LoadScene("PlayerChoice");
    }
}
