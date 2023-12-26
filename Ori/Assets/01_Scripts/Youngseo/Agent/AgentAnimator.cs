using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AgentAnimator : MonoBehaviour
{
    private Animator _animator;
    private PlayerAttack _attack;
    private readonly int _animationNumHash = Animator.StringToHash("animation");
    // 0 : Idle
    // 1 : Walk  x
    // 2 : Run
    // 3 : Jump
    // 4 : Eat  x
    // 5 : Rest  x
    // 6 : Attack
    // 7 : Damage
    // 8 : Die  x
    // 9 : ItemAttack;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _attack = GetComponent<PlayerAttack>();
    }

    public void WalkAnimation(Vector3 dir)
    {
        var value = _animator.GetInteger(_animationNumHash);
        if (value is 3 or 6 or 7) return;
        _animator.SetInteger(_animationNumHash, Equals(dir, Vector3.zero) ? 0 : 2);
    }

    public void JumpAnimation()
    {
        _animator.speed = 0.5f;
        _animator.SetInteger(_animationNumHash, 3);
    }

    public void StopJumpAnimation()
    {
        _animator.speed = 1f;
        _animator.SetInteger(_animationNumHash, 0);
    }

    public void AttackAnimation()
    {
        _animator.SetInteger(_animationNumHash, 6);
    }

    public void StopAttackAnimation()
    { 
        _animator.SetInteger(_animationNumHash, 0);
    }

    public void DamageAnimation()
    {
        StopCoroutine(nameof(DamageAnimationCoroutine));
        StartCoroutine(nameof(DamageAnimationCoroutine));
    }

    private IEnumerator DamageAnimationCoroutine()
    {
        _animator.SetInteger(_animationNumHash, 7);
        yield return new WaitForSeconds(0.5f);
        _animator.SetInteger(_animationNumHash, 0);
    }
}