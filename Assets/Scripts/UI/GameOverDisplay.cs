using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverDisplay : MonoBehaviour
{
    public TMP_Text _scoreText;

    private void Awake()
    {
        //find TMP field (which will contain the score value for display)
        // _scoreText = GetComponent<TMP_Text>();
    }

    public void ShowGameOver(int score)
    {
        gameObject.SetActive(true);
        _scoreText.text = $"Score: {score}";
    }

    public void HideGameOver()
    {
        gameObject.SetActive(false);
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("LevelScene");
    }

    public void MenuButton()
    {

    }
}
