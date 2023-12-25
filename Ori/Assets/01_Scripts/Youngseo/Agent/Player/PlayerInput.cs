using System;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    public UnityEvent<Vector3> OnMoveInput;
    public UnityEvent OnJumpInput;
    public UnityEvent OnAttackInput;
    public UnityEvent OnItemUpInput;
    public UnityEvent OnItemDownInput;
    
    [SerializeField] private float _atkDelay = 1.5f;
    private float _lastAtkTime = -9999f;

    private void Update()
    {
        MoveInput();
        JumpInput();
        AttackInput();
        ItemInput();
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
    
    private void ItemInput()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            OnItemUpInput?.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            OnItemDownInput?.Invoke();
        }
    }
}