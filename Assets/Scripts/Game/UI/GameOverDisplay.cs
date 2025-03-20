using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //ONLY REQUIRED FOR BUTTON
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverDisplay : MonoBehaviour
{
    public HighScoresData scoresData;
    public PlayerData playerData;

    public TMP_Text messageText;
    public TMP_Text scoreText;
    public TMP_Text continueText;
    public Button gameOverButton;
    public GameObject msgBackground;
    public GameObject inputBackground;
    private bool isGameOver = false;
    private bool isNewHighScore = false;
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

    //To show game over screen (with or without new highscore) 
    public void ShowGameOver()
    {
        gameObject.SetActive(true);
        messageText.text = "Game Over";
        scoreText.text = $"Score: {playerData.score}";
        isGameOver = true;
        if(playerData.score > scoresData.highscores.highscoreEntryList[9].score)
        {
            isNewHighScore = true;
            ShowNewHighScore();
            continueText.text = "Update";
        }
        else
        {
            continueText.text = "Continue";
        }
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

    //To show level complete screen  
    public void ShowLevelComplete()
    {
        gameObject.SetActive(true);
        messageText.text = "Level Complete";
        scoreText.text = $"Score: {playerData.score}";
        continueText.text = "Continue";
        isNewHighScore = false;
        isGameOver = false;
    }

    //For UI input or button to trigger addition of new high score
    private void AddHighScore(string input)
    {
        scoresData.AddHighscoreEntry(input, playerData.score);
        DataManager.instance.ResetGame();
        SceneManager.LoadScene("HighScores");
    }

    //For UI input field
    public void NameInput(string input)
    {
        if(input == string.Empty)
        {
            return;
        }
        inputText = input;
        AddHighScore(inputText); //If player presses enter instead of clicking the button
    }

    //For UI button
    public void MenuButton()
    {
        SoundManager.instance.PlaySoundFXClip(SoundManager.instance.buttonSound, transform);
        if(isNewHighScore)
        {
            if(inputText == string.Empty)
            {
                return;
            }
            AddHighScore(inputText);
        }
        else if(isGameOver)
        {
            DataManager.instance.ResetGame();
            SceneManager.LoadScene("MainMenu");
        }
        else
        {
            playerData.AddLevel();
            int index = SceneManager.GetActiveScene().buildIndex + 1;
            SceneManager.LoadScene(index);
        }
    }
}
