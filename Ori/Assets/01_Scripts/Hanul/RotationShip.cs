using System.Collections;
using UnityEngine;

public class RotationShip : MonoBehaviour
{
    public float rotationSpeed = 30f; // ȸ�� �ӵ� (���ӵ�)

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
        // ���ʹϾ� ȸ�� ������ ���
        float angle = rotationSpeed * Time.deltaTime;

        // ���ʹϾ��� �����Ͽ� ȸ�� ����
        transform.rotation *= Quaternion.Euler(angle, 0f, 0f);
    }
}
