using System;
using Packets;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    public UnityEvent<Vector3> OnMoveInput;
    public UnityEvent OnJumpInput;
    public UnityEvent OnAttackInput;
    public UnityEvent OnItemPickUpInput;
    
    [SerializeField] private float _atkDelay = 1.5f;
    private float _lastAtkTime = -9999f;

    private Vector3 dir;

    private void Update()
    {
        MoveInput();
        JumpInput();
        AttackInput();
        ItemInput();
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
    
    private void ItemInput()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            OnItemPickUpInput?.Invoke();
        }
    }
}