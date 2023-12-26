using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class AgentMovement : MonoBehaviour
{
    private Rigidbody _rigid;
    
    [SerializeField] private float _maxSpeed = 10f, _accel = 50, _deAccel = 50;
    private float _currentSpeed = 0;
    private Vector3 _moveDir;
    
    [SerializeField] private float _rotationSpeed = 5f;

    [SerializeField] private float _jumpPower = 5f;

    private bool _isJump;
    private bool _isGround = true;
    private bool _isKnockBack;
    private bool _isStunned;

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 dir)
    {
        if (_isKnockBack || _isStunned || _isJump) return;
        if (dir.sqrMagnitude > 0)
        {
            if (Vector2.Dot(_moveDir, dir) < 0)
            {
                _currentSpeed = 0;
            }
            _moveDir = dir;
            
            Quaternion targetRotation = Quaternion.LookRotation(dir);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * _rotationSpeed);
        }

        _currentSpeed = CalculateSpeed(dir);
        transform.Translate(Vector3.forward * (Time.deltaTime * _currentSpeed));
    }

    public void Stun(float duration)
    {
        StopCoroutine(nameof(StunCoroutine));
        StartCoroutine(nameof(StunCoroutine), duration);
    }

    private IEnumerator StunCoroutine(float duration)
    {
        _isStunned = true;
        yield return new WaitForSeconds(duration);
        _isStunned = false;
    }

    private float CalculateSpeed(Vector3 direction)
    {
        if (direction.sqrMagnitude > 0)
        {
            _currentSpeed += _accel * Time.deltaTime;
        }
        else
        {
            _currentSpeed -= _deAccel * Time.deltaTime;
        }

        return Mathf.Clamp(_currentSpeed, 0, _maxSpeed);
    }

    public void Jump()
    {
        if (_isKnockBack || _isStunned || _isJump) return;
        _isJump = true;
        _rigid.AddForce((Vector3.up + transform.forward) * _jumpPower, ForceMode.Impulse);

        Action action = () => _isJump = false;

        StopCoroutine(nameof(WaitUntilGround));
        StartCoroutine(nameof(WaitUntilGround), action);
    }

    public void KnockBack(Vector3 hitPoint)
    {
        _isKnockBack = true;
        _rigid.velocity = Vector3.zero;
        _rigid.AddExplosionForce(250, hitPoint, 3);
        
        Action action = () =>
        {
            _currentSpeed = 0;
            _isKnockBack = false;
        };
        StopCoroutine(nameof(WaitUntilGround));
        StartCoroutine(nameof(WaitUntilGround), action);
    }

    private IEnumerator WaitUntilGround(Action onComplete)
    {
        yield return new WaitForSeconds(0.1f);
        yield return new WaitUntil(() => _isGround);
        onComplete?.Invoke();
        _rigid.velocity = Vector3.zero;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            _isGround = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            _isGround = false;
        }
    }
}