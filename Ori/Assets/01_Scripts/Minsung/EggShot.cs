using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggShot : MonoBehaviour
{
    /*
    [SerializeField] GameObject egg;
    [SerializeField] Transform firePos;

    public KeyCode skillKey = KeyCode.Q; // ��ų�� ����� Ű
    public float cooldownDuration = 5f; // ��ų ��Ÿ�� (��)

    private bool skillOnCooldown = false; // ��ų�� ��Ÿ�� ������ ����
    private float lastSkillTime; // ���������� ��ų�� ����� �ð�

    void Update()
    {
        // ��ų Ű�� �����鼭 ��Ÿ���� �ƴ� ��
        if (Input.GetKeyDown(skillKey) && !skillOnCooldown)
        {
            UseSkill();
        }

        // ��Ÿ�� ���� ���
        if (skillOnCooldown)
        {
            // ��Ÿ���� �������� Ȯ��
            if (Time.time - lastSkillTime > cooldownDuration)
            {
                // ��Ÿ���� �������� �ٽ� ��� �����ϰ� ����
                skillOnCooldown = false;
            }
        }
    }

    void UseSkill()
    {
        // ���⿡ ��ų ��� �� �����ϴ� �ڵ带 �߰�
        Instantiate(egg, firePos.transform.position, firePos.transform.rotation);
        // ��ų�� ����� �ð��� ��ų�� ��Ÿ�� ������ ����
        lastSkillTime = Time.time;
        skillOnCooldown = true;
    }
    */
}
