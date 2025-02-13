using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class SaveSystemJson
{
    private bool useEncryption = false;
    private readonly string encryptionCode = "tanyetsudpunoak";

    public SaveSystemJson(bool useEncryption)
    {
        this.useEncryption = useEncryption;
    }

    public void SavePlayerData(GameData data)
    {
        try
        {
            string dataToSave = JsonUtility.ToJson(data, true);
            FileStream stream = new FileStream(FilePath(), FileMode.Create);
            if(useEncryption)
            {
                dataToSave = EncryptDecrypt(dataToSave);
            }
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
                if(useEncryption)
                {
                    dataToLoad = EncryptDecrypt(dataToLoad);
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

    //Function to return the file path for saved data
    public static string FilePath()
    {
        string filePath = Application.persistentDataPath + "/game.save";
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
}
