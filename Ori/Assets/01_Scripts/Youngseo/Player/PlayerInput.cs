using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    public UnityEvent<Vector3> OnMove;
    public UnityEvent OnJump;
    public UnityEvent OnAttack;

    private void Update()
    {
        MoveInput();
        JumpInput();
        AttackInput();
    }

    private void MoveInput()
    {
        Vector3 dir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        OnMove?.Invoke(dir.normalized);
    }

    private void JumpInput()
    {
        if (Input.GetButtonDown("Jump"))
        {
            OnJump?.Invoke();
        }
    }
    
    private void AttackInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnAttack?.Invoke();
        }
    }
}