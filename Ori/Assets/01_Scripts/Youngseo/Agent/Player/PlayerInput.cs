using System;
using Packets;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    public UnityEvent<Vector3> OnMoveInput;
    public UnityEvent OnJumpInput;
    public UnityEvent OnAttackInput;
    
    [SerializeField] private float _atkDelay = 1.5f;
    private float _lastAtkTime = -9999f;

    private Vector3 dir;

    private void Update()
    {
        MoveInput();
        JumpInput();
        AttackInput();
    }

    private void MoveInput()
    {
        dir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
        OnMoveInput?.Invoke(dir);
    }

    private void JumpInput()
    {
        if (Input.GetButtonDown("Jump"))
        {
            OnJumpInput?.Invoke();
        }
    }
    
    private void AttackInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Time.time - _lastAtkTime < _atkDelay) return;
            _lastAtkTime = Time.time;

            OnAttackInput?.Invoke();
        }
    }
    
    [SerializeField] private float syncDelay = 0.001f;
    [SerializeField] private float syncDistanceErr = 0.05f;
    private float lastSyncTime = 0f;
    private Vector3 lastSyncPosition = Vector3.zero;
    
    private void LateUpdate()
    {
        if (lastSyncTime + syncDelay > Time.time)
            return;

        if ((lastSyncPosition - transform.position).sqrMagnitude < syncDistanceErr * syncDistanceErr)
            return;

        PlayerPacket playerData = new PlayerPacket();
        playerData.playerID = (ushort)GameManager.Instance.PlayerID;
        playerData.x = transform.position.x;
        playerData.y = transform.position.y;
        playerData.z = transform.position.z;

        playerData.xAngle = transform.rotation.eulerAngles.x;
        playerData.yAngle = transform.rotation.eulerAngles.y;
        playerData.zAngle = transform.rotation.eulerAngles.z;

        playerData.xAnim = dir.x;
        playerData.yAnim = dir.y;
        playerData.zAnim = dir.z;

        C_MovePacket packet = new C_MovePacket();
        packet.playerData = playerData; 
        
        NetworkManager.Instance.Send(packet);

        lastSyncPosition = transform.position;
        lastSyncTime = Time.time;
    }
}