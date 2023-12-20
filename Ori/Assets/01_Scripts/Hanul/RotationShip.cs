using System.Collections;
using UnityEngine;

public class RotationShip : MonoBehaviour
{
    public float rotationSpeed = 30f; // 회전 속도 (각속도)

    private void Update()
    {
        StartCoroutine(RotateRoutine());
    }

    IEnumerator RotateRoutine()
    {
        yield return new WaitForSeconds(10f);
        Rotate();
        yield return new WaitForSeconds(30f);
    }

    void Rotate()
    {
        float time = Time.time;
        Debug.Log(time);
        // 쿼터니언 회전 각도를 계산
        float angle = rotationSpeed * Time.deltaTime;

        // 쿼터니언을 갱신하여 회전 적용
        transform.rotation *= Quaternion.Euler(angle, 0f, 0f);
    }
}
