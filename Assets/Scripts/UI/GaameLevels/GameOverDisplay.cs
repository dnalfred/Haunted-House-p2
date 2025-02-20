using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverDisplay : MonoBehaviour
{
    public PlayerData playerData;
    public TMP_Text scoreText;

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

    private void Update()
    {
        //Show game over screen if player health = 0
        if(playerData.health == 0)
        {
            // ShowGameOver();
        }
    }

    #region HIDE/SHOW GAME OVER
    //To hide game over screen
    public void HideGameOver()
    {
        gameObject.SetActive(false);
    }

    //To show game over screen  
    public void ShowGameOver()
    {
        gameObject.SetActive(true);
        scoreText.text = $"Score: {playerData.score}";
    }
    #endregion

    #region BUTTONS
    //For UI Restart button
    public void RestartButton()
    {
        DataManager.instance.ResetGame();
        SceneManager.LoadScene("LevelScene");
    }

    //For UI Menu button
    public void MenuButton()
    {
        //not yet implemented
    }

    //For UI Exit button
    public void QuitButton()
    {
        Application.Quit();
    }
    #endregion
}
