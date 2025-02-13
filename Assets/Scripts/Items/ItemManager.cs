using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour, DataInterface
{
    private PlayerData playerData;
    private int itemPoints = 100; //points for each item collected
    private bool isCollected = false;
    [SerializeField] private string id;
    [ContextMenu("Generate guid for id")]

    private void Awake()
    {
        //find player object's score controller
        playerData = FindObjectOfType<PlayerData>();
    }

    private void GenerateGuid()
    {
        id = System.Guid.NewGuid().ToString();
    }

    public void LoadData(GameData data)
    {
        data.itemsCollected.TryGetValue(id, out isCollected);
        if(isCollected)
        {
            Destroy(gameObject);
        }
    }

    public void SaveData(ref GameData data)
    {
        if(data.itemsCollected.ContainsKey(id))
        {
            data.itemsCollected.Remove(id);
        }
        data.itemsCollected.Add(id, isCollected);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        //on collision with the player, the item is destroyed and player's score is increased
        if(collider.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            playerData.AddScore(itemPoints);
            isCollected = true;
        }
    }
}
