using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [SerializeField] private AudioSource soundObject;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void PlaySoundClip (AudioClip audioClip, Transform transform, float volume)
    {
        //Create AudioSource gameObject
        AudioSource audioSource = Instantiate(soundObject, transform.position, Quaternion.identity);

        //Assign audioClip
        audioSource.clip = audioClip;

        //Assign volume
        audioSource.volume = volume;

        //Play clip
        audioSource.Play();

        //Destroy AudioSource
        float clipLength = audioSource.clip.length;
        Destroy(audioSource.gameObject, clipLength);
    }
}
