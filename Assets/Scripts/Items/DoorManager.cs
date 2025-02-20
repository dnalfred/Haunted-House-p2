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
    private void OpenDoor()
    {
        if(playerData.isKeyCollected == 1)
        {
            Destroy(gameObject);
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
            OpenDoor();
        }

        if(collision.gameObject.tag == "Player" && isLevelTrigger)
        {
            NextLevel();
        }
    }
}
