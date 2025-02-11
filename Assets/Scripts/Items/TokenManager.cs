using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenManager : MonoBehaviour
{
    private PlayerData playerData;
    private int tokenPoints = 10; //score for each token collected

    private void Awake()
    {
        //find player object's score controller
        playerData = FindObjectOfType<PlayerData>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        //on collision with the player, the token is destroyed and player's score is increased
        if(collider.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            playerData.AddScore(tokenPoints);
        }
    }
}
