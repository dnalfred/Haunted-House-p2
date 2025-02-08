using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreController : MonoBehaviour
{
    public int score { get; private set; }
    public UnityEvent OnScoreChanged;

    //function to add an amount to score
    public void AddScore(int amount)
    {
        score += amount;
        OnScoreChanged.Invoke();
    }

    //function to reset score to 0
    public void ResetScore()
    {
        score = 0;
        OnScoreChanged.Invoke();
    }
}
