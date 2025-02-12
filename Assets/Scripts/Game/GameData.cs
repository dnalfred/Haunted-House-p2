using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int score;
    public int health;
    public int level;

    //constructor to set the default starting values
    public GameData ()
    {
        this.score = 0;
        this.health = 3;
        this.level = 1;
    }
}
