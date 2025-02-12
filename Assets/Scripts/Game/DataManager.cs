using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataManager : MonoBehaviour
{
    private GameData gameData;
    private List<DataInterface> dataObjects;
    public static DataManager instance { get; private set; }

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("Found more than one Data Manager.");
        }
        instance = this;
    }

    private void Start()
    {
        this.dataObjects = FinAllDataObjects();
        LoadGame();
    }

    public void NewGame()
    {
        this.gameData = new GameData();
        Debug.Log("New data created");
    }

    public void LoadGame()
    {
        //load the data
        if (this.gameData == null)
        {
            Debug.Log("Existing data not found");
            NewGame();
        }
        //Pass data to scripts
        foreach(DataInterface dataObject in dataObjects)
        {
            dataObject.LoadData(gameData);
        }
    }

    public void SaveGame()
    {
        //Pass data to scripts to obtain updates
        foreach(DataInterface dataObject in dataObjects)
        {
            dataObject.SaveData(ref gameData);
        }
        //save data
    }

    private void OnApplicationQuit()
    {
        NewGame();
        SaveGame();
    }

    private List<DataInterface> FinAllDataObjects()
    {
        IEnumerable<DataInterface> dataObjects = FindObjectsOfType<MonoBehaviour>().OfType<DataInterface>();
        return new List<DataInterface>(dataObjects);
    }
}
