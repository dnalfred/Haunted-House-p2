using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    // private HowToDisplay howToDisplay;
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
        Debug.Log("Launch status loaded"); //delete
        Debug.Log("Launch status: "+isFirstLaunch); //delete
    }

    public void SaveLaunchStatus()
    {
        PlayerPrefs.SetString("FirstLaunchStatus", isFirstLaunch.ToString());
        Debug.Log("Launch status saved"); //delete
        Debug.Log("Launch status: "+isFirstLaunch); //delete

    }

    public void ResetFirstLaunch()
    {
        isFirstLaunch = true;
        Debug.Log("Launch status reset"); //delete
        SaveLaunchStatus();
    }

    private void OnApplicationQuit()
    {
        ResetFirstLaunch();
    }
}
