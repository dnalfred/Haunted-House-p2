using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    public int displayHealth;
    public Image[] hearts;

    private void Update() 
    {
        //displays hearts from hearts array based on current displayHealth value
        for(int i = 0; i < hearts.Length; i++) 
        {
            if(i < displayHealth) 
            {
                hearts[i].enabled = true;
            } 
            else 
            {
                hearts[i].enabled = false;
            }
        }
    }

    //update displayHealth value
    public void updateHealth(PlayerData playerData)
    {
        displayHealth = playerData.gameData.health;
    }
}
