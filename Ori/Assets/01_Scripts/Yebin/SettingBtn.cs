using UnityEngine;
using UnityEngine.UI;

public class SettingBtn : MonoBehaviour
{
    [SerializeField] private GameObject panel; 
    //[SerializeField] private GameObject uiToolkit; 

    public void SettingBtnClick()
    {
        panel.SetActive(true);  
        //uiToolkit.SetActive(false);
    }
}
