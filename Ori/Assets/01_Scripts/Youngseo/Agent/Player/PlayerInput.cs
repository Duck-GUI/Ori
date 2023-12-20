using System;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    public UnityEvent<Vector3> OnMoveInput;
    public UnityEvent OnJumpInput;
    public UnityEvent OnAttackInput;
    
    [SerializeField] private float _atkDelay = 1.5f;
    private float _lastAtkTime = -9999f;

    private void Update()
    {
        MoveInput();
        JumpInput();
        AttackInput();
    }

    private void MoveInput()
    {
        Vector3 dir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        OnMoveInput?.Invoke(dir.normalized);
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
}