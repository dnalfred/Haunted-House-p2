using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    private TMP_Text _scoreText;

    private void Awake()
    {
        //find TMP field (which will contain the score value for display)
        _scoreText = GetComponent<TMP_Text>();
    }

    //function to update _scoreText (displayed score)
    public void updateScore(ScoreController scoreController)
    {
        _scoreText.text = $"Score: {scoreController.score}";
    }
}
