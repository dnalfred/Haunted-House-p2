using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public bool isFirstLaunch;
    public bool isFirstLaunchPlaying = false;

    public void Awake()
    {
        LoadLaunchStatus();
    }

    public void NotFirstLaunch()
    {
        isFirstLaunch = false;
        SaveLaunchStatus();
    }

    public void FirstLaunchPlaying()
    {
        isFirstLaunchPlaying = true;
    }

    public void LoadLaunchStatus()
    {
        string status = PlayerPrefs.GetString("FirstLaunchStatus");
        if(status == "")
        {
            isFirstLaunch = true;
        }
        else
        {
            isFirstLaunch = (status == "True");
        }
    }

    public void SaveLaunchStatus()
    {
        PlayerPrefs.SetString("FirstLaunchStatus", isFirstLaunch.ToString());
    }

    public void ResetFirstLaunch()
    {
        isFirstLaunch = true;
        SaveLaunchStatus();
    }

    private void OnApplicationQuit()
    {
        ResetFirstLaunch();
    }
}
