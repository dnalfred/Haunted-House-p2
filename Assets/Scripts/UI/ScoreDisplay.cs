using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    private TMP_Text scoreText;

    private void Awake()
    {
        //find TMP field (which will contain the score value for display)
        scoreText = GetComponent<TMP_Text>();
    }

    //function to update _scoreText (displayed score)
    public void updateScore(PlayerData playerData)
    {
        scoreText.text = $"Score: {playerData.score}";
    }
}
