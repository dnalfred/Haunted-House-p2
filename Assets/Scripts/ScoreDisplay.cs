using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    private TMP_Text _scoreText;

    private void Awake()
    {
        _scoreText = GetComponent<TMP_Text>();
    }

    public void updateScore(ScoreController scoreController)
    {
        _scoreText.text = $"Score: {scoreController.score}";
    }
}
