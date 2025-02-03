using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    private ScoreController _scoreController;
    private int _itemScore_token = 10; //score for each token collected

    private void Awake()
    {
        //find player object's score controller
        _scoreController = FindObjectOfType<ScoreController>();
    }

    private void AddItemScore()
    {
        //add token score to player score
        _scoreController.AddScore(_itemScore_token);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            AddItemScore();
        }
    }
}
