using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerDisplay : MonoBehaviour
{
    public PlayerData playerData;
    public TMP_Text timerText;
    public TextMeshProUGUI titleText;
    private float startTime = 3;
    private float timer;
    public float timerSpeed = 1.2f;

    public void Awake()
    {
        playerData = FindObjectOfType<PlayerData>();
    }

    private void Start()
    {
        SoundManager.instance.PlaySoundFXClip(SoundManager.instance.timerSound, transform);
    }

    private void Update()
    {
        timer += Time.deltaTime * timerSpeed;
        if(timer > 1)
        {
            timer = 0f;
            startTime -= 1;

            //Execute this while time is counting down, startTime > 0
            if(startTime > 0)
            {
                timerText.text = startTime.ToString();
                SoundManager.instance.PlaySoundFXClip(SoundManager.instance.timerSound, transform);
            }
            
            //Execute this when startTime = 0
            if (startTime == 0)
            {
                timerText.text = "";
                titleText.fontSize = 250;
                titleText.text = "Go!";
                SoundManager.instance.PlaySoundFXClip(SoundManager.instance.timerSound, transform);
            }

            //Execute this when start time < 0
            if(startTime < 0)
            {
                HideTimer();
                playerData.LevelStarted();
            }
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
