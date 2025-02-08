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

    private void OnTriggerEnter2D(Collider2D collider)
    {
        //on collision with the player, the token is destroyed and player's score is increased
        if(collider.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            _scoreController.AddScore(_tokenScore);
        }
    }
}
