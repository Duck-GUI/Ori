using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MatchRandom : MonoBehaviour
{
    // 씬의 이름을 저장할 배열
    public string[] sceneNames = { "Scene1", "Scene2", "Scene3" };

    // 버튼을 눌렀을 때 호출되는 함수
    public void OnButtonClick()
    {
        LoadRandomScene();
    }

    // 랜덤한 씬을 로드하는 함수
    void LoadRandomScene()
    {
        // 랜덤으로 씬 선택
        int randomIndex = Random.Range(0, sceneNames.Length);
        string randomSceneName = sceneNames[randomIndex];

        Debug.Log(randomSceneName);

        // 선택된 씬으로 로드
        SceneManager.LoadScene(randomSceneName);
    }
}
