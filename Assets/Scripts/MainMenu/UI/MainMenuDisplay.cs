using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuDisplay : MonoBehaviour
{
    private MenuController menuController;
    public InfoDisplay infoDisplay;

    public void Awake()
    {
        menuController = FindObjectOfType<MenuController>();
    }
    
    //For Menu Play button
    public void PlayButton()
    {
        if(menuController.isFirstLaunch)
        {
            menuController.FirstLaunchPlaying();
            menuController.NotFirstLaunch();
            InfoButton();            
        }
        else
        {
            SoundManager.instance.PlaySoundFXClip(SoundManager.instance.buttonSound, transform);
            SceneManager.LoadScene ("Level1", LoadSceneMode.Single);
        }
    }

    //For Menu Information button
    public void InfoButton()
    {
        SoundManager.instance.PlaySoundFXClip(SoundManager.instance.buttonSound, transform);
        infoDisplay.ShowInfo();
    }

    //For Menu High Scores button
    public void ScoresButton()
    {
        SoundManager.instance.PlaySoundFXClip(SoundManager.instance.buttonSound, transform);
        SceneManager.LoadScene ("HighScores", LoadSceneMode.Single);
    }

    //For Menu Quit button
    public void QuitButton()
    {
        SoundManager.instance.PlaySoundFXClip(SoundManager.instance.buttonSound, transform);
        Application.Quit();
    }
}
