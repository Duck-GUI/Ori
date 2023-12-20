using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float totalTime = 60f; // 타이머의 총 시간 (초)
    private float currentTime;     // 현재 남은 시간
    private bool isTimerRunning;    // 타이머가 실행 중인지 여부

    public Text timerText;         // UI에 표시할 텍스트

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
                // 여기에 타이머가 종료될 때의 추가 작업을 수행할 수 있습니다.
            }

            UpdateTimerText();
        }
    }

    void UpdateTimerText()
    {
        // UI 텍스트 업데이트
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
