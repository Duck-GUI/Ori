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
        _rigid.velocity = new Vector3(_moveDir.x * _currentSpeed, _rigid.velocity.y, _moveDir.z * _currentSpeed);
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
        _rigid.AddForce(Vector3.up * _jumpPower, ForceMode.Impulse);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Vector3 rdPos = new Vector3(Mathf.Cos(Random.Range(0, 2 * Mathf.PI)), -0.4f,
                Mathf.Sin(Random.Range(0, 2 * Mathf.PI)));
            KnockBack(transform.position + rdPos);
        }
    }

    public void KnockBack(Vector3 hitPoint)
    {
        StopCoroutine(nameof(KnockBackCoroutine));
        StartCoroutine(nameof(KnockBackCoroutine), hitPoint);
    }

    private IEnumerator KnockBackCoroutine(Vector3 hitPoint)
    {
        _isKnockBack = true;
        _rigid.velocity = Vector3.zero;
        _rigid.AddExplosionForce(300, hitPoint, 3);
        yield return new WaitForSeconds(0.1f);
        while (_isKnockBack)
        {
            if (Physics.Raycast(transform.position, Vector3.down, 0.1f, 1 << 8)) break;
            yield return null;
        }
        _currentSpeed = 0;
        _isKnockBack = false;
    }
}