using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthController : MonoBehaviour
{
    private int maxHealth = 5;
    public int health { get; private set; }
    public UnityEvent OnHealthChanged;
    public bool isInjured = false;

    //deduct 1 from health
    public void DeductHealth() 
    {
        health -= 1;
        OnHealthChanged.Invoke();
        isInjured = true;
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

    //resets health to 3
    public void ResetHealth() 
    {
        health = 3;
        OnHealthChanged.Invoke();
    }
}
