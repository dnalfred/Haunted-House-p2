using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    public int tempMaxHealth = 5;
    public int tempHealth = 3;
    public Image[] hearts;

    private void Update() {

        for(int i = 0; i < hearts.Length; i++) {

            if(i < tempHealth) {
                hearts[i].enabled = true;
            } else {
                hearts[i].enabled = false;
            }
        }
    }
}
