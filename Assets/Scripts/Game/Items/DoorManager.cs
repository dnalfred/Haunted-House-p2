using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    PlayerData playerData;
    [SerializeField] private bool isFakeDoor;
    [SerializeField] private bool isLevelTrigger;
    [SerializeField] private AudioClip doorClosedSound;
    [SerializeField] private AudioClip doorOpenSound;

    private void Awake()
    {
        playerData = FindObjectOfType<PlayerData>();
    }

    //Checks if player has the key to unlock the door
    private void CheckDoor()
    {
        if(playerData.isKeyCollected == 1)
        {
            SoundManager.instance.PlaySoundClip(doorOpenSound, transform, 0.5f);
            Destroy(gameObject);
        }
        else
        {
            SoundManager.instance.PlaySoundClip(doorClosedSound, transform, 0.5f);
        }
    }

    private void NextLevel()
    {
        Debug.Log("Next level");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" && !isFakeDoor && !isLevelTrigger)
        {
            CheckDoor();
        }

        if(collision.gameObject.tag == "Player" && isLevelTrigger)
        {
            NextLevel();
        }
    }
}
