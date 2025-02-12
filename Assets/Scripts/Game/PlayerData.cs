using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerData : MonoBehaviour
{
    public GameData gameData { get; private set; }
    
    public UnityEvent OnScoreChanged;
    public UnityEvent OnHealthChanged;
    
    private int maxHealth = 5;
    public bool isInjured = false;

    public void Start()
    {
        NewGame();
    }

    public void NewGame()
    {
        this.gameData = new GameData();
    }

    //add an amount to score
    public void AddScore(int amount)
    {
        gameData.score += amount;
        OnScoreChanged.Invoke();
    }

    //add 1 to health (up to maxHealth)
    public void AddHealth() 
    {    
        if(gameData.health < maxHealth) 
        {
            gameData.health += 1;
            OnHealthChanged.Invoke();
        }
    }

    //deduct 1 from health
    public void DeductHealth() 
    {
        gameData.health -= 1;
        OnHealthChanged.Invoke();
        isInjured = true;
    }
}
