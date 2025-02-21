using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    // private HowToDisplay howToDisplay;
    [SerializeField] public int isFirstLaunch;
    public int isFirstLaunchPlaying = 0;

    void Awake()
    {
        isFirstLaunch = 1;
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
