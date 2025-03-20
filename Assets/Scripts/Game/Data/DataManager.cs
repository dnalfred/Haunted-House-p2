using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataManager : MonoBehaviour
{
    private GameData gameData;
    private List<DataInterface> dataObjects;
    private SaveSystemJson saveSystem;
    public static DataManager instance { get; private set; }
    [SerializeField] private bool useEncryption;

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
        this.saveSystem = new SaveSystemJson(useEncryption);
        this.dataObjects = FinAllDataObjects();
        LoadGame();
    }

    public void NewGame()
    {
        this.gameData = new GameData();
        Debug.Log("New game data created");
        Debug.Log("[Game Data] "+"Score: "+this.gameData.score + ", Health: "+this.gameData.health + ", Level: "+this.gameData.level+ ", Booleans: "+this.gameData.isLevelStart+", "+this.gameData.isLevelEnd+", "+this.gameData.isKeyCollected);
    }

    public void LoadGame()
    {
        //Load saved game data, if available
        this.gameData = saveSystem.LoadPlayerData();
        if (this.gameData == null)
        {
            Debug.Log("Existing game data not found: To create new");
            NewGame();
        }
        else
        {
            Debug.Log("Game data loaded");
            Debug.Log("[Game Data] "+"Score: "+this.gameData.score + ", Health: "+this.gameData.health + ", Level: "+this.gameData.level+ ", Booleans: "+this.gameData.isLevelStart+", "+this.gameData.isLevelEnd+", "+this.gameData.isKeyCollected);
        }

        //Pass loaded data to other scripts
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

        //Save game data to file
        saveSystem.SavePlayerData(gameData);
        Debug.Log("Game data saved");
        Debug.Log("[Game Data] "+"Score: "+this.gameData.score + ", Health: "+this.gameData.health + ", Level: "+this.gameData.level+ ", Booleans: "+this.gameData.isLevelStart+", "+this.gameData.isLevelEnd+", "+this.gameData.isKeyCollected);

    }

    //Reset all data for a new game
    public void ResetGame()
    {
        Debug.Log("Game data reset");
        NewGame();
        saveSystem.SavePlayerData(gameData);
    }

    public void NextLevel()
    {
        this.gameData.isLevelStart = 1;
        this.gameData.isLevelEnd = 0;
        this.gameData.isKeyCollected = 0;
        gameData.tokensCollected = new SerializableDictionary<string, bool>();
        gameData.itemsCollected = new SerializableDictionary<string, bool>();
    }

    //Resets game data on application quit
    private void OnApplicationQuit()
    {
        ResetGame();
    }

    private List<DataInterface> FinAllDataObjects()
    {
        IEnumerable<DataInterface> dataObjects = FindObjectsOfType<MonoBehaviour>().OfType<DataInterface>();
        return new List<DataInterface>(dataObjects);
    }
}
