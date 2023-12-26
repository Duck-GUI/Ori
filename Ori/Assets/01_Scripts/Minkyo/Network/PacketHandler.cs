using System.Collections;
using System.Collections.Generic;
using HelloNetwork;
using Packets;
using UnityEngine;

public class PacketHandler
{
    public static void S_LogInPacket(Session session, Packet packet)
    {
        S_LogInPacket logInPacket = packet as S_LogInPacket;
        GameManager.Instance.PlayerID = logInPacket.playerID;

        //GameObject.Find("Canvas/LogInPanel").SetActive(false);
    }

    public static void S_MovePacket(Session session, Packet packet)
    {
        S_MovePacket movePacket = packet as S_MovePacket;
        PlayerPacket playerData = movePacket.playerData;

        OtherPlayer player = GameManager.Instance.GetPlayer(playerData.playerID);
        Debug.Log($"Player : {player}");
        player?.SetPosition(movePacket.playerData);
    }

    public static void S_PlayerJoinPacket(Session session, Packet packet)
    {
        S_PlayerJoinPacket joinPacket = packet as S_PlayerJoinPacket;
        GameManager.Instance.AddPlayer(joinPacket.playerData);
    }

    public static void S_RoomEnterPacket(Session session, Packet packet)
    {
        //Scene Name Correction
        S_RoomEnterPacket enterPacket = packet as S_RoomEnterPacket;
        SceneLoader.Instance.LoadSceneAsync("TestGame", () => {
            enterPacket.playerList.ForEach(GameManager.Instance.AddPlayer);
        });
    }
}
