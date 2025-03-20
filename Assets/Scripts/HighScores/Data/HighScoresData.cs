using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using TMPro;

public class HighScoresData : MonoBehaviour
{
    public static HighScoresData instance;
    public HighscoresData highscores;
    public List<HighscoreEntry> highscoreEntryList;
    private List<Transform> highscoreEntryTransformList;
    public int lowestHighScore;

    private readonly string encryptionCode = "uluicedabvanrad"; //contains 5 uncommon three-letter words

    public class HighscoresData
    {
        public List<HighscoreEntry> highscoreEntryList;
    }

    #region AWAKE & START
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        //Load saved highscore data
        LoadHighScores();

        //Reset high scores (for initial setup)
        // ResetHighScores();

        //Create new highscore list (for testing)
        // CreateNewHighScoreList();

        if(highscoreEntryList.Count == 0)
        {
            lowestHighScore = 0;
        }
        else
        {
            lowestHighScore = highscoreEntryList[highscoreEntryList.Count-1].score;
        }
    }

    private void Start()
    {
        // AddHighscoreEntry("ZZZ", 1045); //For testing
    }
    #endregion

    #region CREATE NEW HIGHSCORE LIST
    //Create new highscoreEntryList (for testing)
    private void CreateNewHighScoreList()
    {
        highscoreEntryList = new List<HighscoreEntry>()
        {
            new HighscoreEntry ("AAA", 190),
            new HighscoreEntry ("BBB", 350),
            new HighscoreEntry ("CCC", 90),
            new HighscoreEntry ("DDD", 20),
            new HighscoreEntry ("EEE", 1050),
            new HighscoreEntry ("FFF", 290),
            new HighscoreEntry ("GGG", 40),
            new HighscoreEntry ("HHH", 110),
            new HighscoreEntry ("III", 630),
            new HighscoreEntry ("JJJ", 1250)
        };

        //Sort List
        SortHighScores(highscoreEntryList);

        //Save New High Scores
        highscores = new HighscoresData {highscoreEntryList = highscoreEntryList};
        SaveHighScores();
    }

    //Create new empty highscore list (for initial setup)
    private void ResetHighScores()
    {
        highscoreEntryList = new List<HighscoreEntry>();
        highscores = new HighscoresData {highscoreEntryList = highscoreEntryList};
        SaveHighScores();
    }
    #endregion

    #region ADD & SORT HIGHSCORES
    public void AddHighscoreEntry(string newName, int newScore)
    {
        HighscoreEntry newEntry = new HighscoreEntry (newName, newScore);
        highscores.highscoreEntryList.Add(newEntry);
        SortHighScores(highscores.highscoreEntryList);
        SaveHighScores();
    }

    private void SortHighScores(List<HighscoreEntry> highscoreEntryList)
    {
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
        //Remove eleventh high score list item (if a new item has been added)
        if(highscoreEntryList.Count>10)
        {
            highscoreEntryList.RemoveAt(10);
        }
    }
    #endregion

    #region SAVE & LOAD
    private void SaveHighScores()
    {
        string dataToSave = JsonUtility.ToJson(highscores);
        try
        {
            FileStream stream = new FileStream(FilePath(), FileMode.Create);
            dataToSave = EncryptDecrypt(dataToSave);
            using (stream)
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(dataToSave);
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Error saving data to file: " + e);
        }
    }

    private void LoadHighScores()
    {
        if(File.Exists(FilePath()))
        {
            try
            {
                string dataToLoad = "";
                FileStream stream = new FileStream(FilePath(), FileMode.Open);
                using (stream)
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        dataToLoad = reader.ReadToEnd();
                    }
                }
                dataToLoad = EncryptDecrypt(dataToLoad);
                highscores = JsonUtility.FromJson<HighscoresData>(dataToLoad);
                highscoreEntryList = highscores.highscoreEntryList;
            }
            catch (Exception e)
            {
                Debug.LogError("Error loading data from file: " + e);
            }
        }
    }

    //Function to return the file path for saved highscore data
    public static string FilePath()
    {
        string filePath = Application.persistentDataPath + "/highscores.save";
        return filePath;
    }

    //Function to encrypt / decrypt data
    private string EncryptDecrypt(string data)
    {
        string modifiedData = "";
        for (int i = 0; i < data.Length; i++)
        {
            modifiedData += (char) (data[i] ^ encryptionCode[i % encryptionCode.Length]);
        }
        return modifiedData;
    }
    #endregion
}
