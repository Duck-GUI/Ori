using UnityEngine;
using UnityEngine.UI;

public class SettingBtn : MonoBehaviour
{
    [SerializeField] private GameObject panel;

    [SerializeField] private AudioClip buttonClickSound;
    public AudioSource audioSource;

    public void SettingBtnClick()
    {
        panel.SetActive(true);

        audioSource.PlayOneShot(buttonClickSound);
    }
}
