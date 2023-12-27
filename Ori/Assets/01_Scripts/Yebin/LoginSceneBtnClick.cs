using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginSceneBtnClick : MonoBehaviour
{
    [SerializeField] private AudioClip buttonClickSound;
    public AudioSource audioSource;

    public void LoginBtnClick()
    {
        audioSource.PlayOneShot(buttonClickSound);
    }
}
