using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveShip : MonoBehaviour
{
    //[SerializeField] float raycastDistance = 10f; // ������ �ִ� �Ÿ�
    //void Update()
    //{
    //    // ������Ʈ�� �Ʒ� �������� ���̸� ���ϴ�.
    //    Ray ray = new Ray(transform.position, -transform.up);
    //    RaycastHit hit;

    //    // ���� ���̰� � ��ü�� �浹�ߴٸ�
    //    if (Physics.Raycast(ray, out hit, raycastDistance))
    //    {
    //        // �浹�� ������ ���� ���͸� �����ɴϴ�.
    //        Vector3 hitNormal = hit.normal;

    //        // �ش� ������Ʈ�� ���� ���� �������� ȸ���մϴ�.
    //        Quaternion targetRotation = Quaternion.FromToRotation(transform.up, hitNormal) * transform.rotation;
    //        transform.rotation = targetRotation;
    //    }
    //}
    [SerializeField] float raycastDistance = 10f; // ������ �ִ� �Ÿ�
    [SerializeField] float rotationSpeed = 5f; // ȸ�� �ӵ�

    private Quaternion targetRotation;

    void Update()
    {
        // ������Ʈ�� �Ʒ� �������� ���̸� ���ϴ�.
        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit hit;

        // ���� ���̰� � ��ü�� �浹�ߴٸ�
        if (Physics.Raycast(ray, out hit, raycastDistance))
        {
            // �浹�� ������ ���� ���͸� �����ɴϴ�.
            Vector3 hitNormal = hit.normal;

            // �ش� ������Ʈ�� ���� ���� �������� ȸ���մϴ�.
            targetRotation = Quaternion.FromToRotation(transform.up, hitNormal) * transform.rotation;
        }

        // ���� ȸ�� �������� ��ǥ ȸ�� �������� �ε巴�� ȸ���մϴ�.
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
