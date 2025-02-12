using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerData : MonoBehaviour, DataInterface
{
    // public GameData gameData { get; private set; }
    public int score;
    public int health;
    public int level;
    
    public UnityEvent OnScoreChanged;
    public UnityEvent OnHealthChanged;
    
    private int maxHealth = 5;
    public bool isInjured = false;

    public void LoadData(GameData data)
    {
        this.score = data.score;
        this.health = data.health;
        this.level = data.level;
        Debug.Log("Data loaded");
    }

    public void SaveData(ref GameData data)
    {
        data.score = this.score;
        data.health = this.health;
        data.level = this.level;
        Debug.Log("Data saved");
    }

    //add an amount to score
    public void AddScore(int amount)
    {
        score += amount;
        OnScoreChanged.Invoke();
    }

    //add 1 to health (up to maxHealth)
    public void AddHealth() 
    {    
        if(health < maxHealth) 
        {
            health += 1;
            OnHealthChanged.Invoke();
        }
    }

    //deduct 1 from health
    public void DeductHealth() 
    {
        health -= 1;
        OnHealthChanged.Invoke();
        isInjured = true;
    }
}
