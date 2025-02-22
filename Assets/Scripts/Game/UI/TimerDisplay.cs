using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerDisplay : MonoBehaviour
{
    public PlayerData playerData;
    public TMP_Text timerText;
    public TextMeshProUGUI titleText;
    private float startTime = 4;
    private float timer;

    public void Awake()
    {
        playerData = FindObjectOfType<PlayerData>();
    }

    void Update()
    {
        timer = (float)(Time.deltaTime * 1.2); // timer moves slightly faster than Time.deltaTime
        startTime -= timer;
        int clicks = Mathf.FloorToInt(startTime % 60);
        if(startTime > 0)
        {
            timerText.text = clicks.ToString();
        }
        if(startTime < 1)
        {
            timerText.text = "";
            titleText.fontSize = 250;   
            titleText.text = "Go!";
        }
        if(startTime < 0)
        {
            HideTimer();
            playerData.LevelStarted();
        }
    }

    public void ShowTimer()
    {
        gameObject.SetActive(true);
    }

    private void HideTimer()
    {
        gameObject.SetActive(false);
    }
}
