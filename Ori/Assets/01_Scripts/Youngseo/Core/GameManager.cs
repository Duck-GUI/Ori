using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameManager Instance;
    
    [SerializeField]
    private PoolingListSO _poolListSO;

    private void Awake()
    {
        Instance ??= this;
        
        
    }

    private void CreatePoolManager()
    {
        PoolManager.Instance = new PoolManager(transform);
        foreach (var pair in _poolListSO.Pairs)
        {
            PoolManager.Instance.CreatePool(pair.Prefab, pair.Count);
        }
    }
}