using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MatchRandom : MonoBehaviour
{
    // ���� �̸��� ������ �迭
    public string[] sceneNames = { "Scene1", "Scene2", "Scene3" };

    // ��ư�� ������ �� ȣ��Ǵ� �Լ�
    public void OnButtonClick()
    {
        LoadRandomScene();
    }

    // ������ ���� �ε��ϴ� �Լ�
    void LoadRandomScene()
    {
        // �������� �� ����
        int randomIndex = Random.Range(0, sceneNames.Length);
        string randomSceneName = sceneNames[randomIndex];

        Debug.Log(randomSceneName);

        // ���õ� ������ �ε�
        SceneManager.LoadScene(randomSceneName);
    }
}
