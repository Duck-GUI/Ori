using System;
using System.Collections;
using System.Collections.Generic;
using Packets;
using UnityEngine;

public class ChoicePlayer : MonoBehaviour
{
    private CharacterData _data;

    private void Awake()
    {
        _data = GetComponent<CharacterData>();
    }

    public void Choice()
    {
        C_SelectPacket packet = new C_SelectPacket();
        packet.characterID = _data.characterID;
        
        //내용 추가

        NetworkManager.Instance.Send(packet);
        GameManager.Instance.AddUser(packet.playerData);
    }
}
