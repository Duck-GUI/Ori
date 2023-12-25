using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using HelloNetwork;

public class NetworkManager : MonoBehaviour
{
    public static NetworkManager Instance = null;

    private ServerSession session = null;
    private Connector connector = null;

    private Queue<Packet> packetQueue = new Queue<Packet>();
    private object locker = new object();

    public bool IsConnect = false;
    
    private void Awake()
    {
        //나중에 수정
        string host = Dns.GetHostName();
        IPHostEntry iphost = Dns.GetHostEntry(host);
        IPAddress ipAddress = iphost.AddressList[1];
        IPEndPoint endPoint = new IPEndPoint(ipAddress, 8081);
        
    }
    
    private void Update()
    {
        if(IsConnect == false)
            return;

        while(true)
        {
            lock(locker)
            {
                if(packetQueue.Count <= 0)
                    break;
                
                Packet packet = packetQueue.Dequeue();
                PacketManager.Instance.HandlePacket(session, packet);
            }
        }
    }

    private void OnDestroy()
    {
        if(IsConnect == true)
        {
            session.Close();
        }
    }

    public void Send(Packet packet)
    {
        session.Send(packet.Serialize());
    }

    public void PushPacket(Packet packet)
    {
        lock(locker)
            packetQueue.Enqueue(packet);
    }
}
