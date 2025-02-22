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
        // if(isFirstLaunch != true && isFirstLaunch != false)
        // {
        //     isFirstLaunch = true;
        // }
        // isFirstLaunch = true;
        Debug.Log("Launch status: "+isFirstLaunch); //delete
    }

    public void NotFirstLaunch()
    {
        isFirstLaunch = false;
        SaveLaunchStatus();
        Debug.Log("Launch status: "+isFirstLaunch); //delete
    }

    public void ResetFirstLaunch()
    {
        isFirstLaunch = true;
        SaveLaunchStatus();
        Debug.Log("Launch status: "+isFirstLaunch); //delete
    }

    public void FirstLaunchPlaying()
    {
        isFirstLaunchPlaying = true;
    }

    public void SaveLaunchStatus()
    {
        Debug.Log("Launch status saved"); //delete
        PlayerPrefs.SetString("FirstLaunchStatus", isFirstLaunch.ToString());
    }

    public void LoadLaunchStatus()
    {
        Debug.Log("Launch status loaded"); //delete
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

    private void OnApplicationQuit()
    {
        ResetFirstLaunch();
    }
}
