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

    private void Start()
    {
        //initialise health to 3 using ResetHealth | NOT TESTED
        _healthController.ResetHealth();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            //remove one heart (life) from displayed hearts
           _healthController.RemoveHealth();
        }
    }
}
