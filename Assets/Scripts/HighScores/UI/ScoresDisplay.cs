using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoresDisplay : MonoBehaviour
{
    //For Highscores Continue button
    public void ContinueButton()
    {
        SoundManager.instance.PlaySoundFXClip(SoundManager.instance.buttonSound, transform);
        SceneManager.LoadScene ("MainMenu", LoadSceneMode.Single);
    }
}
