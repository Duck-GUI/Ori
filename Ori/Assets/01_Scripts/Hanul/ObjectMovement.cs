using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    public float speed = 5.0f; // 움직임 속도

    void Update()
    {
        // 수평 및 수직 입력을 가져옴
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        // 이동 방향 설정
        Vector3 movement = new Vector3(-h, 0.0f, -v);

        // 이동 방향에 속도를 곱하여 실제로 이동
        transform.Translate((movement * speed) * Time.deltaTime);
    }
}