using System.Collections;
using UnityEngine;

public class RotationShip : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 30f;
    private int min = -50;
    private int max = 50;
    private bool isRotating = true;

    private void Update()
    {
        if (isRotating)
        {
            Rotate();
        }
    }

    IEnumerator RotateRoutine()
    {
        isRotating = false;
        yield return new WaitForSeconds(8f);
        isRotating = true;
    }

    void Rotate()
    {
        Vector3 eulerAngles = transform.localEulerAngles;

        // 각도를 -180에서 180 범위로 조정하여 처리
        if (eulerAngles.x > 180f)
        {
            eulerAngles.x -= 360f;
        }

        // 각도 범위를 벗어나면 반대 방향으로 변경
        eulerAngles.x += rotationSpeed * Time.deltaTime;
        if (eulerAngles.x >= max || eulerAngles.x <= min)
        {
            StartCoroutine(RotateRoutine());
            rotationSpeed = -rotationSpeed; // 방향 변경
        }

        transform.localEulerAngles = eulerAngles;
    }
}


//public class RotationShip : MonoBehaviour
//{
//    [SerializeField] private float rotationSpeed = 30f; // 회전 속도 (각속도)
//    [SerializeField] private float absrotation = 50;
//    private float coolTime = 8;
//    private float angle;
//    private int a = 1;
//    private int min = -50;
//    private int max = 50;

//    [SerializeField] bool isRotate = true;
//    private void Update()
//    {
//        Rotate();
//    }


//    IEnumerator RotateRoutine()
//    {
//        a = -1;
//        angle = -angle;
//        isRotate = false;
//        yield return new WaitForSeconds(coolTime);
//        isRotate = true;

//    }

//    void Rotate()
//    {
//        transform.eulerAngles = new Vector3(
//            Mathf.Clamp(transform.eulerAngles.x, min, max),
//            transform.eulerAngles.y,
//            transform.eulerAngles.z);
//        if (transform.eulerAngles.x >= max)
//        {
//            Debug.Log("d");
//            if (a == 1) StartCoroutine(RotateRoutine());
//        }

//        if (isRotate)
//        {
//            angle = rotationSpeed * Time.deltaTime;
//            if (a == -1)
//                transform.rotation *= Quaternion.Euler(-angle, 0f, 0f);
//            else
//                transform.rotation *= Quaternion.Euler(angle, 0f, 0f);
//        }

//    }
//}
