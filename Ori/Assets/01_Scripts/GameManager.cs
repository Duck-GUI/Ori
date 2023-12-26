using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Packets;
using Unity.Mathematics;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;

    public static GameManager Instance
    {
        get
        {
            instance ??= GameObject.Find("GameManager").GetComponent<GameManager>();
            return instance;
        }
    }

    [SerializeField] private PoolingListSO _poolListSO;
    [SerializeField] OtherPlayer playerPrefab;
    
    private Dictionary<ushort, OtherPlayer> otherPlayers = new Dictionary<ushort, OtherPlayer>();
    public int PlayerID = -1;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            DestroyImmediate(gameObject);
            return;
        }

        NetworkManager.Instance = gameObject.AddComponent<NetworkManager>();
        SceneLoader.Instance = gameObject.AddComponent<SceneLoader>();
        CreateCameraManager();
        CreatePoolManager();
    }

    public void AddPlayer(PlayerPacket p)
    {
        OtherPlayer player = Instantiate(playerPrefab, new Vector3(p.x, p.y, p.z), Quaternion.identity);
        otherPlayers.Add(p.playerID, player);
    }

    public OtherPlayer GetPlayer(ushort id)
    {
        Debug.Log($"Other Players Count : {otherPlayers.Count}");
        Debug.Log($"Requested Player ID : {id}");

        if(otherPlayers.ContainsKey(id))
            return otherPlayers[id];
        else 
            return null;
    }
    
    private void CreatePoolManager()
    {
        PoolManager.Instance = new PoolManager(transform);
        foreach (var pair in _poolListSO.Pairs)
        {
            PoolManager.Instance.CreatePool(pair.Prefab, pair.Count);
        }
    }

    private void CreateCameraManager()
    {
        CameraManager.Instance = GameObject.Find("MainCam").GetComponent<CameraManager>();
        CameraManager.Instance.Init();
    }
    
    
}
