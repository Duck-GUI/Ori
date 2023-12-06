using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody))]
public class AgentMovement : MonoBehaviour
{
    private Rigidbody _rigid;
    
    [SerializeField] private float _maxSpeed = 10f, _accel = 50, _deAccel = 50;
    private float _currentSpeed = 0;
    private Vector3 _moveDir;
    
    [SerializeField] private float _rotationSpeed = 5f;

    [SerializeField] private float _jumpPower = 5f;

    private bool _isGround = true;
    private bool _isKnockBack;

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 dir)
    {
        if (_isKnockBack) return;
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
        if (_isGround == false) return;
        _isGround = false;
        _rigid.AddForce(Vector3.up * _jumpPower, ForceMode.Impulse);

        Action action = () => _isGround = true;

        StopCoroutine(nameof(WaitUntilGround));
        StartCoroutine(nameof(WaitUntilGround), action);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            float rdRad = Random.Range(0, 2 * Mathf.PI);
            KnockBack(transform.position + new Vector3(Mathf.Cos(rdRad), -0.3f, Mathf.Sin(rdRad)));
        }
    }

    public void KnockBack(Vector3 hitPoint)
    {
        _isKnockBack = true;
        _rigid.velocity = Vector3.zero;
        _rigid.AddExplosionForce(300, hitPoint, 3);
        
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
        yield return new WaitUntil(() => Physics.Raycast(transform.position, Vector3.down, 0.1f, 1 << 8));
        onComplete?.Invoke();
    }
}