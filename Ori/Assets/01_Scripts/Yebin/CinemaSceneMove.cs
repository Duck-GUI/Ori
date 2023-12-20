using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CinemaSceneMove : MonoBehaviour
{
    public Transform destination;  // ���� ����(Transform)�� Inspector���� �����ϼ���.
    private NavMeshAgent navMeshAgent;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        if (destination == null)
        {
            Debug.LogError("���� ������ �������� �ʾҽ��ϴ�. Inspector���� �����ϼ���.");
        }
        else
        {
            StartCoroutine(AutoMoveToDestination());
        }
    }

    IEnumerator AutoMoveToDestination()
    {
        //yield return new WaitForSeconds(1);  // ���� �� 1�� ���

        // ���� �������� �̵�
        navMeshAgent.SetDestination(destination.position);

        // ���� ������ ������ ������ ���
        while (!navMeshAgent.pathPending)
        {
            if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
            {
                if (!navMeshAgent.hasPath || navMeshAgent.velocity.sqrMagnitude == 0f)
                {
                    // �÷��̾ ���� ������ �������� ���� ó��
                    Debug.Log("���� ������ �����߽��ϴ�.");
                    // ���⿡�� �߰����� ������ ������ �� �ֽ��ϴ�.

                    // ���� ���, �� ��ũ��Ʈ�� ��Ȱ��ȭ�ϰų� �ٸ� ������ �����ϵ��� �� �� �ֽ��ϴ�.
                    // gameObject.SetActive(false);
                }
            }

            yield return null;
        }
    }
}
