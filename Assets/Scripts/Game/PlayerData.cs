using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerData : MonoBehaviour
{
    public int score { get; private set; }
    public int health { get; private set; }
    
    public UnityEvent OnScoreChanged;
    public UnityEvent OnHealthChanged;
    
    private int maxHealth = 5;
    public bool isInjured = false;

    public void Start()
    {
        ResetScore();
        ResetHealth();
    }

    //function to reset score to 0
    public void ResetScore()
    {
        score = 0;
        OnScoreChanged.Invoke();
    }

    //resets health to 3
    public void ResetHealth() 
    {
        health = 3;
        OnHealthChanged.Invoke();
    }

    //function to add an amount to score
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
