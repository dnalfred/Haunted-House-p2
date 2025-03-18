using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverDisplay : MonoBehaviour
{
    public HighScoresData scoresData;
    public PlayerData playerData;
    public TMP_Text messageText;
    public TMP_Text scoreText;
    public TMP_Text continueText;
    public GameObject msgBackground;
    public GameObject inputBackground;
    private bool isGameOver;
    private bool isNewHighScore;
    public string inputText; 

    private void Awake()
    {
        //Find scoresData object
        scoresData = FindObjectOfType<HighScoresData>();

        //Find playerData object
        playerData = FindObjectOfType<PlayerData>();
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
        if(playerData.score > scoresData.highscores.highscoreEntryList[9].score)
        {
            ShowNewHighScore();
            continueText.text = "Add Score";
            isNewHighScore = true;
        }
        else
        {
            continueText.text = "Continue";
        }
        isGameOver = true;
    }

    public void ShowNewHighScore()
    {
        msgBackground.SetActive(true);
        inputBackground.SetActive(true);
    }

    public void HideNewHighScore()
    {
        msgBackground.SetActive(false);
        inputBackground.SetActive(false);
    }

    //To show level compeltet screen  
    public void ShowLevelComplete()
    {
        gameObject.SetActive(true);
        messageText.text = "Level Complete";
        scoreText.text = $"Score: {playerData.score}";
        continueText.text = "Continue";
        isNewHighScore = false;
        isGameOver = false;
    }

    //For UI input field
    public void NameInput(string input)
    {
        inputText = input;
        scoresData.AddHighscoreEntry(inputText, playerData.score);
        DataManager.instance.ResetGame();
        SceneManager.LoadScene("HighScores");
    }

    //For UI Menu button
    public void MenuButton()
    {
        SoundManager.instance.PlaySoundFXClip(SoundManager.instance.buttonSound, transform);
        if(isNewHighScore)
        {
            scoresData.AddHighscoreEntry(inputText, playerData.score);
            DataManager.instance.ResetGame();
            SceneManager.LoadScene("HighScores");
        }
        else if(isGameOver)
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
