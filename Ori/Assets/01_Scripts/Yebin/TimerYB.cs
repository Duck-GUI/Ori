using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerYB : MonoBehaviour
{
    public Text timerText;
    public float time = 60f;
    private float selectCountDown;

    private void Start()
    {
        selectCountDown = time;
    }

    private void Update()
    {
        if (Mathf.Floor(selectCountDown) <= 0)
        {
            // Count 0�ϋ� ������ �Լ� ����
        }
        else
        {
            selectCountDown -= Time.deltaTime;
            timerText.text = Mathf.Floor(selectCountDown).ToString();
        }
    }
}
