using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginSceneBtnClick : MonoBehaviour
{
    [SerializeField] private AudioClip buttonClickSound;
    public AudioSource audioSource;

    public void LoginBtnClick()
    {
        audioSource.PlayOneShot(buttonClickSound);
    }

    public void Entrance()
    {
        audioSource.PlayOneShot(buttonClickSound);
    }
}
