using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverDisplay : MonoBehaviour
{
    public PlayerData playerData;
    public TMP_Text messageText;
    public TMP_Text scoreText;
    private bool isGameOver;

    private void Awake()
    {
        //Find playerData object
        playerData = FindObjectOfType<PlayerData>();
    }

    private void Start()
    {
        //Hide game over screen when game starts
        HideGameOver();
    }

    //To hide game over screen
    public void HideGameOver()
    {
        gameObject.SetActive(false);
    }

    //To show game over screen  
    public void ShowGameOver()
    {
        gameObject.SetActive(true);
        messageText.text = "Game Over";
        scoreText.text = $"Score: {playerData.score}";
        isGameOver = true;
    }

    //To show level compeltet screen  
    public void ShowLevelComplete()
    {
        gameObject.SetActive(true);
        messageText.text = "Level Complete";
        scoreText.text = $"Score: {playerData.score}";
        isGameOver = false;
    }

    //For UI Menu button
    public void MenuButton()
    {
        Debug.Log("Continue button clicked"); //delete
        SoundManager.instance.PlaySoundFXClip(SoundManager.instance.buttonSound, transform);
        if(isGameOver)
        {
            DataManager.instance.ResetGame();
            SceneManager.LoadScene("MainMenu");
        }
        else
        {
            Debug.Log("NEXT LEVEL FUNCTION HERE");
        }
    }
}
