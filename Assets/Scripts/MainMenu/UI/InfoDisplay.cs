using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class InfoDisplay : MonoBehaviour
{
    private MenuController menuController;

    public void Awake()
    {
        menuController = FindObjectOfType<MenuController>();
    }

    //For Menu Play button
    public void ContinueButton()
    {
        SoundManager.instance.PlaySoundFXClip(SoundManager.instance.buttonSound, transform);
        if(menuController.isFirstLaunchPlaying)
        {
            SceneManager.LoadScene ("Level1", LoadSceneMode.Single);
        }
        else if(menuController.isFirstLaunch)
        {
            menuController.NotFirstLaunch();
            HideInfo();
        }
        else
        {
            HideInfo();
        }
    }

    //To hide Information screen
    public void HideInfo()
    {
        gameObject.SetActive(false);
    }

    //To show Information screen  
    public void ShowInfo()
    {
        gameObject.SetActive(true);
    }
}
