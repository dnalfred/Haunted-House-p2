using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    private ScoreController _scoreController;
    private int _itemScore = 100; //score for each item collected

    private void Awake()
    {
        //find player object's score controller
        _scoreController = FindObjectOfType<ScoreController>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        //on collision with the player, the item is destroyed and player's score is increased
        if(collider.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            _scoreController.AddScore(_itemScore);
        }
    }
}
