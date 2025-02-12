using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverDisplay : MonoBehaviour
{
    private PlayerData playerData;
    public TMP_Text scoreText;

    private void Awake()
    {
        playerData = FindObjectOfType<PlayerData>();
    }

    public void ShowGameOver()
    {
        gameObject.SetActive(true);
        scoreText.text = $"Score: {playerData.gameData.score}";
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
