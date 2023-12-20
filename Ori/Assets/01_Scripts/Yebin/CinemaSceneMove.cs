using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CinemaSceneMove : MonoBehaviour
{
    public Transform destination;  // 목적 지점(Transform)을 Inspector에서 설정하세요.
    private NavMeshAgent navMeshAgent;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        if (destination == null)
        {
            Debug.LogError("목적 지점이 설정되지 않았습니다. Inspector에서 설정하세요.");
        }
        else
        {
            StartCoroutine(AutoMoveToDestination());
        }
    }

    IEnumerator AutoMoveToDestination()
    {
        //yield return new WaitForSeconds(1);  // 시작 후 1초 대기

        // 목적 지점으로 이동
        navMeshAgent.SetDestination(destination.position);

        // 목적 지점에 도착할 때까지 대기
        while (!navMeshAgent.pathPending)
        {
            if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
            {
                if (!navMeshAgent.hasPath || navMeshAgent.velocity.sqrMagnitude == 0f)
                {
                    // 플레이어가 목적 지점에 도착했을 때의 처리
                    Debug.Log("목적 지점에 도착했습니다.");
                    // 여기에서 추가적인 로직을 수행할 수 있습니다.

                    // 예를 들어, 이 스크립트를 비활성화하거나 다른 동작을 수행하도록 할 수 있습니다.
                    // gameObject.SetActive(false);
                }
            }

            yield return null;
        }
    }
}
