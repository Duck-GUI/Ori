using System;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class AgentHp : MonoBehaviour
{
    [SerializeField] private int _maxHp = 100;

    public UnityEvent<Vector3> OnDamaged;

    private int ReceivedDamage
    {
        get => _receivedDamage;
        set => _receivedDamage = Mathf.Clamp(value, 0, _maxHp);
    }

    private int _receivedDamage;

    private void Start()
    {
        ReceivedDamage = _maxHp;
    }

    public void Damage(int value)
    {
        ReceivedDamage += value;
        float rdRad = Random.Range(0, 2 * Mathf.PI);
        OnDamaged?.Invoke(transform.position + new Vector3(Mathf.Cos(rdRad), -0.3f, Mathf.Sin(rdRad)));
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Damage(5);
        }
    }
}