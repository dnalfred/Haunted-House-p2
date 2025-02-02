using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenManager : MonoBehaviour
{
    private ScoreController _scoreController;
    private int _tokenScore = 10; //score for each token collected

    private void Awake()
    {
        //find player object's score controller
        _scoreController = FindObjectOfType<ScoreController>();
    }

    private void Start()
    {
        //initialise score to 8 using ResetScore
        _scoreController.ResetScore();
    }

    private void AddTokenScore()
    {
        //add token score to player score
        _scoreController.AddScore(_tokenScore);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            AddTokenScore();
        }
    }
}
