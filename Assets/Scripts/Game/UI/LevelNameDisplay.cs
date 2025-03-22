using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelNameDisplay : MonoBehaviour
{
    [SerializeField] private int levelNumber;
    private TMP_Text levelNameText;
    private string[] levelNames = {"Entrance", "Grand Staircase", "Second Floor", "Library", "Kitchen"};

    private void Awake()
    {
        //find TMP field (which will contain the level name to display)
        levelNameText = GetComponent<TMP_Text>();
    }

    private void Start()
    {
        levelNameText.text = levelNames[levelNumber-1];
    }

    // public void UpdateLevelName(PlayerData playerData)
    // {
    //     if(playerData.isLevelStart == 1)
    //     {
    //         levelNameText.text = levelNames[playerData.level-1];
    //     }
    // }
}
