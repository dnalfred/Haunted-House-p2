using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public PlayerData playerData;
    public GameOverDisplay gameOverDisplay;
    public TimerDisplay timerDisplay;

    private void Awake()
    {
        //Find playerData object
        playerData = FindObjectOfType<PlayerData>();
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

    private void GameOver()
    {
        gameOverDisplay.ShowGameOver();
    }
}
