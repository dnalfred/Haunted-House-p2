using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class SaveSystemJson
{
    public void SavePlayerData(GameData data)
    {
        try
        {
            string dataToSave = JsonUtility.ToJson(data, true);
            FileStream stream = new FileStream(FilePath(), FileMode.Create);
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

    public GameData LoadPlayerData()
    {
        GameData loadedData = null;
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
                loadedData = JsonUtility.FromJson<GameData>(dataToLoad);
            }
            catch (Exception e)
            {
                Debug.LogError("Error loading data from file: " + e);
            }
        }

        return loadedData;
    }

    public static string FilePath()
    {
        string filePath = Application.persistentDataPath + "/game.save";
        return filePath;
    }
}
