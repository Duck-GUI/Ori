using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XBtn : MonoBehaviour
{
    [SerializeField] private GameObject panel;

    [SerializeField] private AudioClip buttonClickSound;
    public AudioSource audioSource;

    public void XBtnClick()
    {
        panel.SetActive(false);

        audioSource.PlayOneShot(buttonClickSound);
    }
}
