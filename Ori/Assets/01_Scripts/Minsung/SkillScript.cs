using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Unity.VisualScripting;

public class SkilScript : MonoBehaviour
{
    #region ������ų
    /*
    
    [SerializeField] private float KnockbackValue = 10;
    [SerializeField] private Transform _transform;
    [SerializeField] private float skillCoolTime;
    [SerializeField] private int pigSpeed = 5;
    bool isUseSkill;

    void Start()
    {
        isUseSkill = false;
        _transform = GetComponent<Transform>();
    }

    void Update()
    {
        if(isUseSkill == false)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                PigSkill();
                StartCoroutine(pigSkillCool());
            }
        }
    }

    private void PigSkill()
    {
        transform.DOScale(new Vector3(2, 2, 2),0.3f);
    }

    IEnumerator pigSkillCool()
    {
        print("��ų");
        if(isUseSkill == false)
        {
            isUseSkill = true;
            yield return new WaitForSeconds(skillCoolTime);
            transform.DOScale(new Vector3(1, 1, 1), 0.3f);
            isUseSkill = false;
            print("��ų ����");
        }
    }
    */
    #endregion
    #region �䳢��ų

    /*
    [SerializeField]
    private float movePosition = 10f;
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
        transform.DOMoveY(movePosition, 0.8f);

        // ��ų�� ����� �ð��� ��ų�� ��Ÿ�� ������ ����
        lastSkillTime = Time.time;
        skillOnCooldown = true;
    }
    */
    #endregion
    #region ����ī��ų
    
    /*
    [SerializeField]
    private float walkSpeed;

    private Rigidbody myRigid;

    void Start()
    {
        myRigid = GetComponent<Rigidbody>();
    }

   
    private void Move()
    {
        float _moveDirX = Input.GetAxisRaw("Horizontal");
        float _moveDirZ = Input.GetAxisRaw("Vertical");

        Vector3 velocity = new Vector3(_moveDirX, 0, _moveDirZ).normalized * walkSpeed;

        myRigid.MovePosition(transform.position + velocity * Time.deltaTime);
    }

   
   
    public KeyCode skillKey = KeyCode.Q; // ��ų�� ����� Ű
    public float cooldownDuration = 5f; // ��ų ��Ÿ�� (��)
    
    private bool skillOnCooldown = false; // ��ų�� ��Ÿ�� ������ ����
    private float lastSkillTime; // ���������� ��ų�� ����� �ð�

    void Update()
    {
        Move();


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
        walkSpeed = 50;

        // ��ų�� ����� �ð��� ��ų�� ��Ÿ�� ������ ����
        lastSkillTime = Time.time;
        skillOnCooldown = true;
    }

   */
    #endregion
}
