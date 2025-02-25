using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    PlayerData playerData;
    [SerializeField] private bool isFakeDoor;
    [SerializeField] private bool isLevelTrigger;

    private void Awake()
    {
        playerData = FindObjectOfType<PlayerData>();
    }

    //Checks if player has the key to unlock the door
    private void CheckDoor()
    {
        if(playerData.isKeyCollected == 1)
        {
            SoundManager.instance.PlaySoundFXClip(SoundManager.instance.doorOpeningSound, transform);
            Destroy(gameObject);
        }
        else
        {
            SoundManager.instance.PlaySoundFXClip(SoundManager.instance.doorLockedSound, transform);
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
