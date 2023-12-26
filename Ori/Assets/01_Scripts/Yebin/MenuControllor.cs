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

    [Header("Setting Button")]
    [SerializeField] private VisualTreeAsset settingButtonsTemplate;
    private VisualElement settingButtons;
    private Button settingButton;
    private VisualElement buttonsWrapper;

    private Button exitButton;

    [Header("Mute Button")]
    [SerializeField] private Sprite mutedSprite;
    [SerializeField] private Sprite unmutedSprite;
    private bool muted;
    private Button muteButton;

    [SerializeField] private AudioClip buttonClickSound;
    public AudioSource audioSource;

    private void Awake()
    {
        doc = GetComponent<UIDocument>();

        playButton = doc.rootVisualElement.Q<Button>("PlayButton");
        playButton.clicked += PlayButtoOnClicked; // () => { Dosomething();}

        buttonsWrapper = doc.rootVisualElement.Q<VisualElement>("Buttons");

        settingButton = doc.rootVisualElement.Q<Button>("SettingButton");
        settingButton.clicked += SettingButtonOnClick;

        settingButtons = settingButtonsTemplate.CloneTree();
        var backButton = settingButtons.Q<Button>("BackButton");
        backButton.clicked += BackButtonOnClicked;  

        exitButton = doc.rootVisualElement.Q<Button>("ExitButton");
        exitButton.clicked += ExitButtOnClicked;

        muteButton = doc.rootVisualElement.Q<Button>("MuteButton");
        muteButton.clicked += MuteButtonOnClicked;
    }

    private void PlayButtoOnClicked()
    {
        SceneManager.LoadScene("Test"); // Scene 이름 수정
        audioSource.PlayOneShot(buttonClickSound);
    }

    private void SettingButtonOnClick()
    {
        buttonsWrapper.Clear();
        buttonsWrapper.Add(settingButtons);

        audioSource.PlayOneShot(buttonClickSound);
    }

    private void BackButtonOnClicked()
    {
        buttonsWrapper.Clear();
        buttonsWrapper.Add(playButton);
        buttonsWrapper.Add(settingButton);
        buttonsWrapper.Add(exitButton);

        audioSource.PlayOneShot(buttonClickSound);
    }

    private void ExitButtOnClicked()
    {
        Application.Quit();

        audioSource.PlayOneShot(buttonClickSound);
    }

    private void MuteButtonOnClicked()
    {
        audioSource.PlayOneShot(buttonClickSound);
        
        muted = !muted;
        var bg = muteButton.style.backgroundImage;
        bg.value = Background.FromSprite(muted ? mutedSprite : unmutedSprite);
        muteButton.style.backgroundImage = bg;

        AudioListener.volume = muted ? 0 : 1;
    }
}
