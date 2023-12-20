using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    public float speed = 5.0f; // ������ �ӵ�

    void Update()
    {
        // ���� �� ���� �Է��� ������
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        // �̵� ���� ����
        Vector3 movement = new Vector3(-h, 0.0f, -v);

        // �̵� ���⿡ �ӵ��� ���Ͽ� ������ �̵�
        transform.Translate((movement * speed) * Time.deltaTime);
    }
}