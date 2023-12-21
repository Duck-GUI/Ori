using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    [SerializeField]
    private PoolingListSO _poolListSO;

    private void Awake()
    {
        Instance ??= this;
        
        CreateCameraManager();
        CreatePoolManager();
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