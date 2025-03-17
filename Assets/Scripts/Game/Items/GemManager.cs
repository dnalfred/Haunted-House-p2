using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GemManager : MonoBehaviour, DataInterface
{
    private Rigidbody2D body;
    private PlayerData playerData;
    
    private int itemPoints = 100; //points for each item collected
    [SerializeField] private string id;
    public bool isCollected = false;
    public UnityEvent OnGemCollected;
    private float startingPosY;

    private void Awake()
    {
        //Find component on the item object
        body = gameObject.GetComponent<Rigidbody2D>();

        //find player object
        playerData = FindObjectOfType<PlayerData>();
    }

    private void Start()
    {
        //Set item gravity scale to 0 at start
        body.gravityScale = 0;

        //Set Y starting position
        startingPosY = body.position.y;

        HideGem();
    }

    private void Update()
    {
        //Destroy item object if isCollected and has moved a certain distance
        if(isCollected)
        {
            if((body.position.y - startingPosY)>1)
            {
                Destroy(gameObject);
            }
        }
    }

    public void HideGem()
    {
        gameObject.SetActive(false);
    }

    public void ShowGem()
    {
        gameObject.SetActive(true);
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
        //on collision with the player, the item is destroyed and player's score is increased
        if(collider.gameObject.tag == "Player")
        {
            //Play sound on collection
            SoundManager.instance.PlaySoundFXClip(SoundManager.instance.gemSound, transform);

            //Cause item to "jump" up on collection
            body.gravityScale = 1;
            body.velocity = new Vector2(0, 6);

            //Add score and set isCollected
            playerData.AddScore(itemPoints);
            isCollected = true;

            //Invoke OnGemCollected event
            OnGemCollected.Invoke();
        }
    }
}
