using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.UI;

public class SpringAnim : MonoBehaviour
{
    float time;

    private void Update()
    {
        if (time < 0.4f) // Ư�� ��ġ���� �������� �̵�
        {
            this.transform.position = new Vector3(0, 12 - 30 * time, 0);
        }
        else if (time < 0.5f) // ƨ���
        {
            this.transform.position = new Vector3(0, time - 0.4f, 0) * 4;
        }
        else if (time < 0.6f) // ƨ���
        {
            this.transform.position = new Vector3(0, 0.6f - time, 0) * 4;
        }
        else if(time < 0.7f) // ƨ���
        {
            this.transform.position = new Vector3(0, (time - 0.6f) / 2, 0) * 4;
        }
        else if(time < 0.8f) // ƨ���
        {
            this.transform.position = new Vector3(0, 0.05f - (time - 0.7f) / 2, 0) * 4;
        }
        else // ƨ���
        {
            this.transform.position = Vector3.zero;
        }
        time += Time.deltaTime;
    }

    public void resetAnim()
    {
        time = 0;
    }
}
