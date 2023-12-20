using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameManager Instance;

    private void Awake()
    {
        Instance ??= this;
        
        
    }

    private void CreateCameraManager()
    {
        
    }

    private void CreatePoolManager()
    {
        
    }
}