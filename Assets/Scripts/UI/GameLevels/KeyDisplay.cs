using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDisplay : MonoBehaviour
{
    private void Start()
    {
        //Hide key when game starts
        // HideKey();
    }

    public void HideKey()
    {
        Debug.Log("HideKey triggered");
        gameObject.SetActive(false);
    }

    public void ShowKey(PlayerData playerData)
    {
        if(playerData.isKeyCollected == 1)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
