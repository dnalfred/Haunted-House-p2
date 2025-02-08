using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameOverDisplay _GameOverDisplay;
    private ScoreController _ScoreController;
    private HealthController _HealthController;

    private void Awake()
    {
        //hide game over screen when game starts
        _GameOverDisplay.HideGameOver();

        //find player object's health controller
        _HealthController = FindObjectOfType<HealthController>();

        //find player objects's score controller
        _ScoreController = FindObjectOfType<ScoreController>();
    }

    private void Start()
    {
        //initialise health at start of game
        _HealthController.ResetHealth();

        //initialise score at start of game
        _ScoreController.ResetScore();
    }

    private void GameOver()
    {
        _GameOverDisplay.DisplayGameOver(_ScoreController.score);
    }
}
