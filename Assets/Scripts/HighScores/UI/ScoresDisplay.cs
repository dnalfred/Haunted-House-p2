using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoresDisplay : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;
    float templateHeight = 60f;

    private void Awake()
    {
        //Find 
        entryContainer = transform.Find("HighscoreEntries");
        entryTemplate = entryContainer.Find("EntryTemplate");

        //Hide black highscore entry
        entryTemplate.gameObject.SetActive(false);
    }

    private void Start()
    {
        DisplayScores();
    }

    private void DisplayScores()
    {
        for(int i=0; i<10; i++)
        {
            //Instatiat a new highscore entry at the correct location
            Transform entryTransform = Instantiate(entryTemplate, entryContainer);
            RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
            entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight*i);
            entryTransform.gameObject.SetActive(true);

            //Set rank string
            int rank = i+1;
            string rankString;
            switch (rank)
            {
                default: rankString = rank + "th"; break;
                case 1: rankString = "1st"; break;
                case 2: rankString = "2nd"; break;
                case 3: rankString = "3rd"; break;
            }
            entryTransform.Find("posText").GetComponent<TMP_Text>().text = rankString;

            //Set score string
            int score = Random.Range (0, 1000);
            string scoreString = score.ToString();
            entryTransform.Find("scoreText").GetComponent<TMP_Text>().text = scoreString;

            //Set name string
            string nameString = "AAA";
            entryTransform.Find("nameText").GetComponent<TMP_Text>().text = nameString;
        }
    }

    //For Highscores Continue button
    public void ContinueButton()
    {
        SoundManager.instance.PlaySoundFXClip(SoundManager.instance.buttonSound, transform);
        SceneManager.LoadScene ("MainMenu", LoadSceneMode.Single);
    }
}
