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
    }*/
    #endregion
    #region 토끼스킬
    /*
    private int movePosition = 6;

   
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Rabbit();
        }
    }
    private void Rabbit()
    {
            transform.DOMoveY(movePosition, 0.8f);
    }
    */
    #endregion

    #region 알파카스킬
    [SerializeField]
    private float walkSpeed;

    private Rigidbody myRigid;

    void Start()
    {
        myRigid = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();
        AlpakaSkill();
    }


    private void AlpakaSkill()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            StartCoroutine("AlpakaSkillCor");

        }
    }
    private void Move()
    {
        float _moveDirX = Input.GetAxisRaw("Horizontal");
        float _moveDirZ = Input.GetAxisRaw("Vertical");

        Vector3 velocity = new Vector3(_moveDirX, 0, _moveDirZ).normalized * walkSpeed;

        myRigid.MovePosition(transform.position + velocity * Time.deltaTime);
    }

    IEnumerator AlpakaSkillCor()
    {
        walkSpeed = 50;
        yield return new WaitForSeconds(5f);
        walkSpeed = 5;
        yield return new WaitForSeconds(10f);
    }

   
    #endregion
}
