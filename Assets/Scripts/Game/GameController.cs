using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public PlayerData playerData;
    public GameOverDisplay gameOverDisplay;

    public bool isGameOver = false;

    private void Awake()
    {
        //find playerData object
        playerData = FindObjectOfType<PlayerData>();
    }

    private void Update()
    {
        //Triggers game over
        if(playerData.health == 0)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        isGameOver = true;
        gameOverDisplay.ShowGameOver();
    }
}
