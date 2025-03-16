using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScoresData : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;
    private List<HighscoreEntry> highscoreEntryList;
    private List<Transform> highscoreEntryTransformList;
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
        CreateNewLists();
    }

    private void CreateNewLists()
    {
        //Create new highscoreEntryList (for testing)
        highscoreEntryList = new List<HighscoreEntry>()
        {
            new HighscoreEntry { score = 1233, name = "AAA"},
            new HighscoreEntry { score = 455, name = "BBB"},
            new HighscoreEntry { score = 102, name = "CCC"},
            new HighscoreEntry { score = 783, name = "DDD"},
            new HighscoreEntry { score = 1045, name = "EEE"},
            new HighscoreEntry { score = 287, name = "FFF"},
            new HighscoreEntry { score = 65, name = "GGG"},
            new HighscoreEntry { score = 953, name = "HHH"},
            new HighscoreEntry { score = 627, name = "III"},
            new HighscoreEntry { score = 1312, name = "JJJ"},
        };

        //Sort List
        for (int i=0; i<highscoreEntryList.Count; i++)
        {
            for (int j=i+1; j<highscoreEntryList.Count; j++)
            {
                //Check if next element is larger
                if(highscoreEntryList[j].score > highscoreEntryList[i].score)
                {
                    //Swap
                    HighscoreEntry temporaryEntry = highscoreEntryList[i];
                    highscoreEntryList[i] = highscoreEntryList[j];
                    highscoreEntryList[j] = temporaryEntry;
                }
            }
        }

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

    private class HighscoreEntry
    {
        public string name;
        public int score;
    }
}
