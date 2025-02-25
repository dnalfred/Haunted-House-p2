using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverDisplay : MonoBehaviour
{
    public PlayerData playerData;
    public TMP_Text scoreText;

    private void Awake()
    {
        //Find playerData object
        playerData = FindObjectOfType<PlayerData>();
    }

    private void Start()
    {
        //Hide game over screen when game starts
        HideGameOver();
    }

    //To hide game over screen
    public void HideGameOver()
    {
        gameObject.SetActive(false);
    }

    //To show game over screen  
    public void ShowGameOver()
    {
        gameObject.SetActive(true);
        scoreText.text = $"Score: {playerData.score}";
    }

    //For UI Menu button
    public void MenuButton()
    {
        Debug.Log("Continue button clicked"); //delete
        DataManager.instance.ResetGame();
        SoundManager.instance.PlaySoundFXClip(SoundManager.instance.buttonSound, transform);
        SceneManager.LoadScene("MainMenu");
    }
}
