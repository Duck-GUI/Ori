using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XBtn : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    //[SerializeField] private GameObject uiToolkit;

    public void XBtnClick()
    {
        panel.SetActive(false);
        //uiToolkit.SetActive(true);
    }
}
