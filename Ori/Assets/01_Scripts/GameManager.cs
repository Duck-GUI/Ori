using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Packets;
using SingularityGroup.HotReload;
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
    
    private Dictionary<ushort, OtherPlayer> _otherPlayers = new Dictionary<ushort, OtherPlayer>();
    private Dictionary<ushort, NetworkUser> _userPlayers = new Dictionary<ushort, NetworkUser>();
    public int PlayerID = -1;

    private NetworkUser _user = null;

    private void Awake()
    {
        if (instance == null)
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
        //CreateUIManager();
    }

    public NetworkUser GetUser()
    {
        if (_user != null) return _user;
        _user = FindObjectOfType<NetworkUser>();
        return _user;
    }

    public void AddPlayer(PlayerPacket p)
    {
        OtherPlayer player = Instantiate(playerPrefab, new Vector3(p.x, p.y, p.z), Quaternion.identity);
        player.OtherID = p.playerID;
        _otherPlayers.Add(p.playerID, player);
    }

    public OtherPlayer GetPlayer(ushort id)
    {
        //Debug.Log($"Other Players Count : {_otherPlayers.Count}");
        //Debug.Log($"Requested Player ID : {id}");

        if(_otherPlayers.ContainsKey(id))
            return _otherPlayers[id];
        else 
            return null;
    }

    private void CreateUIManager()
    {
        GameObject uiManager = new GameObject("UIManager") { transform = { parent = transform } };
        UIManager.Instance = uiManager.AddComponent<UIManager>();
        //주석 제거 및 수정
        //UIManager.Instance.Init(GameObject.Find("Canvas").transform);
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
