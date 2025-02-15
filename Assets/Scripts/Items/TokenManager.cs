using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenManager : MonoBehaviour, DataInterface
{
    private PlayerData playerData;
    private int itemPoints = 10; //points for each token collected
    private bool isCollected = false;

    private void Awake()
    {
        //find player object's score controller
        playerData = FindObjectOfType<PlayerData>();
    }

    [SerializeField] private string id;
    [ContextMenu("Generate guid for id")]
    private void GenerateGuid()
    {
        id = System.Guid.NewGuid().ToString();
    }

    public void LoadData(GameData data)
    {
        data.tokensCollected.TryGetValue(id, out isCollected);
        if(isCollected)
        {
            Destroy(gameObject);
        }
    }

    public void SaveData(ref GameData data)
    {
        if(data.tokensCollected.ContainsKey(id))
        {
            data.tokensCollected.Remove(id);
        }
        data.tokensCollected.Add(id, isCollected);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        //on collision with the player, the token is destroyed and player's score is increased
        if(collider.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            playerData.AddScore(itemPoints);
            isCollected = true;
        }
    }
}
