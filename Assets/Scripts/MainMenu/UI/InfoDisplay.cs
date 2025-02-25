using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class InfoDisplay : MonoBehaviour
{
    private MenuController menuController;
    [SerializeField] private AudioClip buttonSound;

    public void Awake()
    {
        menuController = FindObjectOfType<MenuController>();
    }

    //For Menu Play button
    public void ContinueButton()
    {
        Debug.Log("Continue clicked!"); //delete
        SoundManager.instance.PlaySoundFXClip(SoundManager.instance.buttonSound, transform);
        if(menuController.isFirstLaunchPlaying)
        {
            SceneManager.LoadScene ("LevelScene", LoadSceneMode.Single);
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

    //To hide how to play screen
    public void HideInfo()
    {
        gameObject.SetActive(false);
    }

    //To show how to play screen  
    public void ShowInfo()
    {
        gameObject.SetActive(true);
    }
}
