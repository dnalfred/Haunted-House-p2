using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    private Rigidbody2D body;
    private PlayerData playerData;
    [SerializeField] private bool isFakeDoor;
    [SerializeField] private bool isLevelTrigger;
    private float doorOpeningSpeed = 1.5f;

    private void Awake()
    {
        playerData = FindObjectOfType<PlayerData>();
        
        //Find components on the door object
        body = gameObject.GetComponent<Rigidbody2D>();
    }

    //Checks if player has the key to unlock the door
    private void CheckDoor()
    {
        if(playerData.isKeyCollected == 1)
        {
            SoundManager.instance.PlaySoundFXClip(SoundManager.instance.doorOpeningSound, transform);
            OpenDoor();
        }
        else
        {
            SoundManager.instance.PlaySoundFXClip(SoundManager.instance.doorLockedSound, transform);
        }
    }

    private void OpenDoor()
    {
        body.velocity = new Vector2(doorOpeningSpeed, body.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" && !isFakeDoor && !isLevelTrigger)
        {
            CheckDoor();
        }

        if(collision.gameObject.tag == "levelTrigger")
        {
            Debug.Log("Door destroyed");
            Destroy(gameObject);
        }

        if(collision.gameObject.tag == "Player" && isLevelTrigger)
        {
            Debug.Log("Next level");
        }
    }

    // private void OnTriggerEnter2D(Collider2D collider)
    // {
    //     if(collider.gameObject.tag == "levelTrigger")
    //     {
    //         Debug.Log("Door destroyed");
    //         Destroy(gameObject);
    //     }

    //     if(collider.gameObject.tag == "Player" && isLevelTrigger)
    //     {
    //         NextLevel();
    //     }
    // }
}
