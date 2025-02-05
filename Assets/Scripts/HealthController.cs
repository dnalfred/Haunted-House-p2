using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthController : MonoBehaviour
{
    private int maxHealth = 5;
    public int health { get; private set; }
    public UnityEvent OnHealthChanged;

    //function to deduct 1 from health
    public void RemoveHealth() {
        health -= 1;
        OnHealthChanged.Invoke();
    }

    //function to add 1 to health (up to maxHealth)
    public void AddHealth() {
        
        if(health < maxHealth) {
            health += 1;
            OnHealthChanged.Invoke();
        }
    }

    //function to reset health to 3 | NOT TESTED
    public void ResetHealth() {
        health = 3;
        OnHealthChanged.Invoke();
    }
}
