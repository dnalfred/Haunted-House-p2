using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class HighScoresDisplay : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;
    public HighScoresData scoresData;
    public List<HighscoreEntry> highscoreEntryList;
    private List<Transform> highscoreEntryTransformList;
    float templateHeight = 60f;

    public class HighscoresData
    {
        public List<HighscoreEntry> highscoreEntryList;
    }

    private void Awake()
    {
        //Find 
        entryContainer = transform.Find("HighscoreEntries");
        entryTemplate = entryContainer.Find("EntryTemplate");        

        //Hide black highscore entry
        entryTemplate.gameObject.SetActive(false);

        //Find HighScoresData object
        scoresData = FindObjectOfType<HighScoresData>();
    }

    private void Start()
    {
        //Display High Scores Table
        DisplayHighScores(scoresData.highscores.highscoreEntryList);
    }

    private void DisplayHighScores(List<HighscoreEntry> highscoreEntryList)
    {
        //Create new highscoreEntryTransformList
        highscoreEntryTransformList = new List<Transform>();

        //Populate high score table
        foreach (HighscoreEntry highscoreEntry in highscoreEntryList)
        {
            CreateHighScoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
        }
    }

    //Create a single highscore entry
    private void CreateHighScoreEntryTransform (HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList)
    {
        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight*transformList.Count);
        entryTransform.gameObject.SetActive(true);

        //Set rank
        int rank = transformList.Count+1;
        string rankString;
        switch (rank)
        {
            default: rankString = rank + "th"; break;
            case 1: rankString = "1st"; break;
            case 2: rankString = "2nd"; break;
            case 3: rankString = "3rd"; break;
        }
        entryTransform.Find("posText").GetComponent<TMP_Text>().text = rankString;

        //Set score
        int score = highscoreEntry.score;
        string scoreString = score.ToString();
        entryTransform.Find("scoreText").GetComponent<TMP_Text>().text = scoreString;

        //Set name
        string nameString = highscoreEntry.name;
        entryTransform.Find("nameText").GetComponent<TMP_Text>().text = nameString;

        transformList.Add(entryTransform);
    }

    //For Highscores Continue button
    public void ContinueButton()
    {
        SoundManager.instance.PlaySoundFXClip(SoundManager.instance.buttonSound, transform);
        SceneManager.LoadScene ("MainMenu", LoadSceneMode.Single);
    }
}
