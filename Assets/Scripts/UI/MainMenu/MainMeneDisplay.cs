using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMeneDisplay : MonoBehaviour
{
    //For Menu Play button
    public void PlayButton()
    {
        Debug.Log("Play button clicked!"); //delete
        SceneManager.LoadScene ("LevelScene", LoadSceneMode.Single);
    }

    //For Menu Information button
    public void InfoButton()
    {
        Debug.Log("Info button clicked!"); //delete
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
