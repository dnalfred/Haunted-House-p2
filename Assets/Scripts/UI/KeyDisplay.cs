using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDisplay : MonoBehaviour
{
    private void Start()
    {
        //Hide key when game starts
        HideKey();
    }

    public void HideKey()
    {
        gameObject.SetActive(false);
    }

    public void ShowKey(PlayerData playerData)
    {
        gameObject.SetActive(true);
    }
}
