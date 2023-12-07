using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    public UnityEvent<Vector3> OnMoveInput;
    public UnityEvent OnJumpInput;
    public UnityEvent OnAttackInput;

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
            OnAttackInput?.Invoke();
        }
    }
}