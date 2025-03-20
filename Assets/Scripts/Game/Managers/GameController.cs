using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public PlayerData playerData;
    public GameOverDisplay gameOverDisplay;
    public TimerDisplay timerDisplay;
    public GemManager gemManager;
    private bool isFirstLaunch;
    private float gemTimer = 0;
    private float gemHiddenTime = 6;
    private float gemShowTime = 3f;
    private int finalLevelNo = 2;

    private void Awake()
    {
        //Find playerData object
        playerData = FindObjectOfType<PlayerData>();

        //Load game first launch status (to reset if necessary)
        LoadLaunchStatus();
    }

    private void Start()
    {
        //Set gemHiddenTime value
        SetHiddenTime();

        //Reset Game Over and New High Score Displays
        gameOverDisplay.HideGameOver();
        gameOverDisplay.HideNewHighScore();
    }

    private void Update()
    {
        //Triggers displays of Timer screen at level start
        if(playerData.isLevelStart == 1)
        {
            timerDisplay.ShowTimer();
        }

        //Triggers game over
        if(playerData.health == 0)
        {
            GameOver();
        }

        if(gemManager.isCollected == false)
        {
            gemTimer += Time.deltaTime;
            if(gemTimer > gemHiddenTime)
            {
                gemManager.ShowGem();
            }
            if(gemTimer > (gemHiddenTime+gemShowTime))
            {
                gemTimer = 0;
                gemManager.HideGem();
                SetHiddenTime();
            }
        }
    }

    private void SetHiddenTime()
    {
        gemHiddenTime = Random.Range(6, 12);
        // Debug.Log("Gem Hidden Time: "+gemHiddenTime); //For testing
    }

    //To show game over screen
    private void GameOver()
    {
        gameOverDisplay.ShowGameOver();
    }

    //To show level complete screen
    public void NextLevel()
    {
        if(playerData.level > finalLevelNo)
        {
            gameOverDisplay.ShowGameOver();
        }
        else
        {
            gameOverDisplay.ShowLevelComplete();
        }
    }
    
    #region SAVE FIRST LAUNCH STATUS ON APPLICATION QUIT
    private void LoadLaunchStatus()
    {
        string status = PlayerPrefs.GetString("FirstLaunchStatus");
        if(status == "")
        {
            isFirstLaunch = true;
        }
        else
        {
            isFirstLaunch = (status == "True");
        }
    }

    private void SaveLaunchStatus()
    {
        PlayerPrefs.SetString("FirstLaunchStatus", isFirstLaunch.ToString());
    }

    private void ResetFirstLaunch()
    {
        isFirstLaunch = true;
        SaveLaunchStatus();
    }

    private void OnApplicationQuit()
    {
        ResetFirstLaunch();
    }
    #endregion
}
