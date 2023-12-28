using System;
using System.Collections;
using System.Collections.Generic;
using Packets;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    private InputField idField;

    private void Awake()
    {
        idField = GetComponent<InputField>();
    }

    public void LogIn()
    {
        C_LogInPacket packet = new C_LogInPacket();
        packet.nickname = idField.text;
        NetworkManager.Instance.Send(packet);
    }
}
