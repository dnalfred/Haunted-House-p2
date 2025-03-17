using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int score;
    public int health;
    public int level;
    public int isLevelStart;
    public int isLevelEnd;
    public int isKeyCollected;
    public SerializableDictionary<string, bool> tokensCollected;
    public SerializableDictionary<string, bool> itemsCollected;

    //constructor to set the default starting values
    public GameData ()
    {
        this.score = 0;
        this.health = 3;
        this.level = 1;
        this.isLevelStart = 1;
        this.isLevelEnd = 0;
        this.isKeyCollected = 0;
        tokensCollected = new SerializableDictionary<string, bool>();
        itemsCollected = new SerializableDictionary<string, bool>();
    }
}
