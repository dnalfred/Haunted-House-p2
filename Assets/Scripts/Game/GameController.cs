using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public PlayerData playerData;
    public GameOverDisplay gameOverDisplay;

    private void Awake()
    {
        //hide game over screen when game starts
        gameOverDisplay.HideGameOver();

        playerData = FindObjectOfType<PlayerData>();
    }

    private void Update()
    {
        if(playerData.health == 0)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        gameOverDisplay.ShowGameOver(playerData.score);
    }
}
