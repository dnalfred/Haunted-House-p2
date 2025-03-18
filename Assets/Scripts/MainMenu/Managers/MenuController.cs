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
        Debug.Log("Launch status loaded: "+isFirstLaunch); //for testing
    }

    public void SaveLaunchStatus()
    {
        PlayerPrefs.SetString("FirstLaunchStatus", isFirstLaunch.ToString());
        Debug.Log("Launch status saved: "+isFirstLaunch); //for testing
    }

    public void ResetFirstLaunch()
    {
        isFirstLaunch = true;
        Debug.Log("Launch status reset"); //for testing
        SaveLaunchStatus();
    }

    private void OnApplicationQuit()
    {
        ResetFirstLaunch();
    }
}
