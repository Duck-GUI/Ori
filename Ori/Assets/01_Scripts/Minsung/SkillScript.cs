using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

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
}
