using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggShot : MonoBehaviour
{
    /*
    [SerializeField] GameObject egg;
    [SerializeField] Transform firePos;

    public KeyCode skillKey = KeyCode.Q; // 스킬을 사용할 키
    public float cooldownDuration = 5f; // 스킬 쿨타임 (초)

    private bool skillOnCooldown = false; // 스킬이 쿨타임 중인지 여부
    private float lastSkillTime; // 마지막으로 스킬을 사용한 시간

    void Update()
    {
        // 스킬 키를 누르면서 쿨타임이 아닐 때
        if (Input.GetKeyDown(skillKey) && !skillOnCooldown)
        {
            UseSkill();
        }

        // 쿨타임 중인 경우
        if (skillOnCooldown)
        {
            // 쿨타임이 끝났는지 확인
            if (Time.time - lastSkillTime > cooldownDuration)
            {
                // 쿨타임이 끝났으면 다시 사용 가능하게 설정
                skillOnCooldown = false;
            }
        }
    }

    void UseSkill()
    {
        // 여기에 스킬 사용 시 동작하는 코드를 추가
        Instantiate(egg, firePos.transform.position, firePos.transform.rotation);
        // 스킬을 사용한 시간과 스킬이 쿨타임 중임을 설정
        lastSkillTime = Time.time;
        skillOnCooldown = true;
    }
    */
}
