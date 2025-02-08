using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // public GameOverScreen gameOverScreen;
    private ScoreController scoreController;
    private HealthController healthController;

    private void Awake()
    {
        //hide game over screen when game starts
        // gameOverScreen.HideGameOver();

        //find player object's health controller
        healthController = FindObjectOfType<HealthController>();

        //find player objects's score controller
        scoreController = FindObjectOfType<ScoreController>();
    }

    private void Start()
    {
        //initialise health at start of game
        healthController.ResetHealth();

        //initialise score at start of game
        scoreController.ResetScore();
    }

    private void GameOver()
    {
        // gameOverScreen.DisplayGameOver(scoreController.score);
    }
}
