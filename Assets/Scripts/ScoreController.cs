using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreController : MonoBehaviour
{
    public int score { get; private set; }
    public UnityEvent OnScoreChanged;

    public void AddScore(int amount)
    {
        score += amount;
        OnScoreChanged.Invoke();
    }

    public void ResetScore()
    {
        score = 0;
        OnScoreChanged.Invoke();
    }
}
