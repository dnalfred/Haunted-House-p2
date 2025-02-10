using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private HealthController _healthController;

    private void Awake()
    {
        //find player object's health controller
        _healthController = FindObjectOfType<HealthController>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            //remove one heart (life) from displayed hearts
           _healthController.RemoveHealth();

            //TEMP TO REMOVE
           Destroy(gameObject);
        }
    }
}
