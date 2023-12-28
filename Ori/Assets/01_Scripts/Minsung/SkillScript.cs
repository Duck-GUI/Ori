using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Unity.VisualScripting;

public class SkilScript : MonoBehaviour
{
    #region 돼지스킬
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
        print("스킬");
        if(isUseSkill == false)
        {
            isUseSkill = true;
            yield return new WaitForSeconds(skillCoolTime);
            transform.DOScale(new Vector3(1, 1, 1), 0.3f);
            isUseSkill = false;
            print("스킬 종료");
        }
    }
    */
    #endregion
    #region 토끼스킬

    /*
    [SerializeField]
    private float movePosition = 10f;
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
        transform.DOMoveY(movePosition, 0.8f);

        // 스킬을 사용한 시간과 스킬이 쿨타임 중임을 설정
        lastSkillTime = Time.time;
        skillOnCooldown = true;
    }
    */
    #endregion
    #region 알파카스킬
    
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

   
   
    public KeyCode skillKey = KeyCode.Q; // 스킬을 사용할 키
    public float cooldownDuration = 5f; // 스킬 쿨타임 (초)
    
    private bool skillOnCooldown = false; // 스킬이 쿨타임 중인지 여부
    private float lastSkillTime; // 마지막으로 스킬을 사용한 시간

    void Update()
    {
        Move();


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
        walkSpeed = 50;

        // 스킬을 사용한 시간과 스킬이 쿨타임 중임을 설정
        lastSkillTime = Time.time;
        skillOnCooldown = true;
    }

   */
    #endregion
}
