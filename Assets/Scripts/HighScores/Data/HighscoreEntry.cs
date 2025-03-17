using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HighscoreEntry
{
    public string name;
    public int score;

    public HighscoreEntry(string name, int score)
    {
        this.name = name;
        this.score = score;
    }
}
