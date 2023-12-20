using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveShip : MonoBehaviour
{
    //[SerializeField] float raycastDistance = 10f; // 레이의 최대 거리
    //void Update()
    //{
    //    // 오브젝트의 아래 방향으로 레이를 쏩니다.
    //    Ray ray = new Ray(transform.position, -transform.up);
    //    RaycastHit hit;

    //    // 만약 레이가 어떤 물체와 충돌했다면
    //    if (Physics.Raycast(ray, out hit, raycastDistance))
    //    {
    //        // 충돌한 지점의 법선 벡터를 가져옵니다.
    //        Vector3 hitNormal = hit.normal;

    //        // 해당 오브젝트를 법선 벡터 방향으로 회전합니다.
    //        Quaternion targetRotation = Quaternion.FromToRotation(transform.up, hitNormal) * transform.rotation;
    //        transform.rotation = targetRotation;
    //    }
    //}
    [SerializeField] float raycastDistance = 10f; // 레이의 최대 거리
    [SerializeField] float rotationSpeed = 5f; // 회전 속도

    private Quaternion targetRotation;

    void Update()
    {
        // 오브젝트의 아래 방향으로 레이를 쏩니다.
        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit hit;

        // 만약 레이가 어떤 물체와 충돌했다면
        if (Physics.Raycast(ray, out hit, raycastDistance))
        {
            // 충돌한 지점의 법선 벡터를 가져옵니다.
            Vector3 hitNormal = hit.normal;

            // 해당 오브젝트를 법선 벡터 방향으로 회전합니다.
            targetRotation = Quaternion.FromToRotation(transform.up, hitNormal) * transform.rotation;
        }

        // 현재 회전 각도에서 목표 회전 각도까지 부드럽게 회전합니다.
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
