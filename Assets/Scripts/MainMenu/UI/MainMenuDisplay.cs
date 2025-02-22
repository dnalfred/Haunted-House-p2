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
        Debug.Log("Play button clicked!"); //delete
        if(menuController.isFirstLaunch == 1)
        {
            menuController.FirstLaunchPlaying();
            menuController.NotFirstLaunch();
            InfoButton();            
        }
        else
        {
            SceneManager.LoadScene ("LevelScene", LoadSceneMode.Single);
        }
    }

    //For Menu Information button
    public void InfoButton()
    {
        Debug.Log("Info button clicked!"); //delete
        infoDisplay.ShowInfo();
    }

    //For Menu High Scores button
    public void ScoresButton()
    {
        Debug.Log("Scores button clicked!"); //delete
    }

    //For Menu Quit button
    public void QuitButton()
    {
        Debug.Log("Quit button clicked!"); //delete
        Application.Quit();
    }
}
