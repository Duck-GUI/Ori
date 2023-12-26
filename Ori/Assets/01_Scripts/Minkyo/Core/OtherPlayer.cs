using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Packets;

public class OtherPlayer : MonoBehaviour
{
    private Animator _animator;
    private readonly int _animationNumHash = Animator.StringToHash("animation");

    private void Awake()
    {
        _animator = transform.Find("Visual").GetComponent<Animator>();
    }

    public void WalkAnimation_Net(PlayerPacket playerData)
    {
        Vector3 dir = Vector3.zero;
        dir.x = playerData.xAnim;
        dir.y = playerData.yAnim;
        dir.z = playerData.zAnim;
        
        var value = _animator.GetInteger(_animationNumHash);
        if (value is 3 or 6 or 7) return;
        _animator.SetInteger(_animationNumHash, Equals(dir, Vector3.zero) ? 0 : 2);
    }
    
    public void SetPosition(PlayerPacket playerData)
    {
        Vector3 pos = transform.position;
        pos.x = playerData.x;
        pos.y = playerData.y;
        pos.z = playerData.z;

        Vector3 anglePos = transform.rotation.eulerAngles;
        anglePos.x = playerData.xAngle;
        anglePos.y = playerData.yAngle;
        anglePos.z = playerData.zAngle;

        transform.position = pos;
        transform.rotation = Quaternion.Euler(anglePos.x, anglePos.y, anglePos.z);
    }
    
    
}
