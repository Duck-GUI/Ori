using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MenuControllor : MonoBehaviour
{
    private UIDocument doc;

    private Button playButton;
    private Button settingButton;
    private Button exitButton;

    [Header("Mute Button")]
    [SerializeField] private Sprite mutedSprite;
    [SerializeField] private Sprite unmutedSprite;
    private bool muted;

    private Button muteButton;

    private void Awake()
    {
        doc = GetComponent<UIDocument>();

        playButton = doc.rootVisualElement.Q<Button>("PlayButton");
        playButton.clicked += PlayButtoOnClicked; // () => { Dosomething();}

        playButton = doc.rootVisualElement.Q<Button>("SettingButton");


        playButton = doc.rootVisualElement.Q<Button>("ExitButton");
        exitButton.clicked += ExitButtOnClicked;

        playButton = doc.rootVisualElement.Q<Button>("MuteButton");
        muteButton.clicked += MuteButtonOnClicked;
    }

    private void PlayButtoOnClicked()
    {
        SceneManager.LoadScene("Test"); // Scene 이름 수정
    }

    private void ExitButtOnClicked()
    {
        Application.Quit();
    }

    private void MuteButtonOnClicked()
    {
        muted = !muted;
        var bg = muteButton.style.backgroundImage;
        bg.value = Background.FromSprite(muted ? mutedSprite : unmutedSprite);
        muteButton.style.backgroundImage = bg;

        AudioListener.volume = muted ? 0 : 1;
    }
}
