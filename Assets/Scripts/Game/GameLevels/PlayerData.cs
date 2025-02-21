using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerData : MonoBehaviour, DataInterface
{
    public int score;
    public int health;
    public int level;
    public int isLevelStart;
    public int isKeyCollected;
    
    public UnityEvent OnScoreChanged;
    public UnityEvent OnHealthChanged;
    public UnityEvent OnLevelChanged;
    public UnityEvent OnKeyCollected;
    
    private int maxHealth = 5;
    public bool isInjured = false;
    public bool isDead = false;

    //Function to load game data via Data Interface
    public void LoadData(GameData data)
    {
        this.score = data.score;
        this.health = data.health;
        this.level = data.level;
        this.isLevelStart = data.isLevelStart;
        this.isKeyCollected = data.isKeyCollected;
        OnScoreChanged.Invoke();
        OnHealthChanged.Invoke();
        OnLevelChanged.Invoke();
        OnKeyCollected.Invoke();
    }

    //Function to save game data via Data Interface
    public void SaveData(ref GameData data)
    {
        data.score = this.score;
        data.health = this.health;
        data.level = this.level;
        data.isLevelStart = this.isLevelStart;
        data.isKeyCollected = this.isKeyCollected;
    }

    //Set isLevelStart to 0 (false)
    public void LevelStarted()
    {
        isLevelStart = 0;
    }
    
    //Add an amount to score
    public void AddScore(int amount)
    {
        score += amount;
        OnScoreChanged.Invoke();
    }

    //Add 1 to health (up to maxHealth)
    public void AddHealth() 
    {    
        if(health < maxHealth) 
        {
            health += 1;
            OnHealthChanged.Invoke();
        }
    }

    //Deduct 1 from health
    public void DeductHealth() 
    {
        health -= 1;
        OnHealthChanged.Invoke();
        isInjured = true;
        if(health == 0)
        {
            isDead = true;
        }
    }

    //Add 1 to level
    public void AddLevel()
    {
        level += 1;
        OnScoreChanged.Invoke();
    }
    
    public void KeyCollected()
    {
        isKeyCollected = 1;
        OnKeyCollected.Invoke();
    }
}
