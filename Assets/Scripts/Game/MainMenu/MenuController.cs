using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    // private HowToDisplay howToDisplay;
    public int isFirstLaunch;
    public int isFirstLaunchPlaying;

    void Awake()
    {
        isFirstLaunch = 1;
        isFirstLaunchPlaying = 0;
    }

    void Update()
    {
        
    }

    public void NotFirstLaunch()
    {
        isFirstLaunch = 0;
    }

    public void FirstLaunchPlaying()
    {
        isFirstLaunchPlaying = 1;
    }
}
