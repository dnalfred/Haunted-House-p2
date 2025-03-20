using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelNameDisplay : MonoBehaviour
{
    private TMP_Text levelNameText;
    private string[] levelNames = {"Entrance", "Grand Staircase", "Bedroom", "Library", "Kitchen"};

    private void Awake()
    {
        //find TMP field (which will contain the level name to display)
        levelNameText = GetComponent<TMP_Text>();
    }

    public void UpdateLevelName(PlayerData playerData)
    {
        if(playerData.isLevelStart == 1)
        {
            levelNameText.text = levelNames[playerData.level-1];
        }
    }
}
