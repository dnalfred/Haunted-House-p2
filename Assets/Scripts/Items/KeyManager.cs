using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeyManager : MonoBehaviour, DataInterface
{
private PlayerData playerData;
    
    private int itemPoints = 100; //points for each key collected
    [SerializeField] private string id;
    private bool isCollected = false;
    public UnityEvent OnKeyCollected;

    private void Awake()
    {
        //find player object's score controller
        playerData = FindObjectOfType<PlayerData>();
    }

    [ContextMenu("Generate guid for id")]
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
        //On collision with the player, the item is removed and player's score is increased
        if(collider.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            playerData.AddScore(itemPoints);
            isCollected = true;
            OnKeyCollected.Invoke();
        }
    }
}
