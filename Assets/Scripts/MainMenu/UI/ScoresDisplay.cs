using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoresDisplay : MonoBehaviour
{
    private MenuController menuController;

    public void Awake()
    {
        menuController = FindObjectOfType<MenuController>();
    }

    //For Menu Play button
    public void ContinueButton()
    {
        Debug.Log("Continue clicked!"); //delete
        SoundManager.instance.PlaySoundFXClip(SoundManager.instance.buttonSound, transform);
        HideScores();
    }

    //To hide how to play screen
    public void HideScores()
    {
        gameObject.SetActive(false);
    }

    //To show how to play screen  
    public void ShowScores()
    {
        gameObject.SetActive(true);
    }
}
