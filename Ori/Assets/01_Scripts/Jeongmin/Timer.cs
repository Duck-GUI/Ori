using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float totalTime = 60f; // Ÿ�̸��� �� �ð� (��)
    private float currentTime;     // ���� ���� �ð�
    private bool isTimerRunning;    // Ÿ�̸Ӱ� ���� ������ ����

    public Text timerText;         // UI�� ǥ���� �ؽ�Ʈ

    void Start()
    {
        currentTime = totalTime;
        isTimerRunning = false;
        UpdateTimerText();
    }

    void Update()
    {
        if (isTimerRunning)
        {
            currentTime -= Time.deltaTime;

            if (currentTime <= 0f)
            {
                currentTime = 0f;
                isTimerRunning = false;
                // ���⿡ Ÿ�̸Ӱ� ����� ���� �߰� �۾��� ������ �� �ֽ��ϴ�.
            }

            UpdateTimerText();
        }
    }

    void UpdateTimerText()
    {
        // UI �ؽ�Ʈ ������Ʈ
        int minutes = Mathf.FloorToInt(currentTime / 60f);
        int seconds = Mathf.FloorToInt(currentTime % 60f);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void StartTimer()
    {
        isTimerRunning = true;
    }

    public void StopTimer()
    {
        isTimerRunning = false;
    }

    public void ResetTimer()
    {
        currentTime = totalTime;
        UpdateTimerText();
    }
}
