using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public PlayerData playerData;
    public GameOverDisplay gameOverDisplay;
    public TimerDisplay timerDisplay;
    private bool isFirstLaunch;

    private void Awake()
    {
        //Find playerData object
        playerData = FindObjectOfType<PlayerData>();

        //Load game first launch status (to reset if necessary)
        LoadLaunchStatus();
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
    }

    //To show game over screen
    private void GameOver()
    {
        gameOverDisplay.ShowGameOver();
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
        Debug.Log("Launch status loaded: "+isFirstLaunch); //delete
    }

    private void SaveLaunchStatus()
    {
        PlayerPrefs.SetString("FirstLaunchStatus", isFirstLaunch.ToString());
        Debug.Log("Launch status saved: "+isFirstLaunch); //delete
    }

    private void ResetFirstLaunch()
    {
        isFirstLaunch = true;
        Debug.Log("Launch status reset"); //delete
        SaveLaunchStatus();
    }

    private void OnApplicationQuit()
    {
        ResetFirstLaunch();
    }
    #endregion
}
