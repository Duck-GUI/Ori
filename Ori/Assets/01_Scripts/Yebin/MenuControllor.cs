using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.UIElements;

public class MenuControllor : MonoBehaviour
{
    private UIDocument doc;
    private Button playButton;
    private Button settingButton;
    private Button exitButton;
    private Button muteButton;

    private void Awake()
    {
        doc = GetComponent<UIDocument>();
        playButton = doc.rootVisualElement.Q<Button>("PlayButton");
        playButton = doc.rootVisualElement.Q<Button>("SettingButton");
        playButton = doc.rootVisualElement.Q<Button>("ExitButton");
        playButton = doc.rootVisualElement.Q<Button>("MuteButton");
    }
}
