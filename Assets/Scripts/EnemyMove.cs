using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private Rigidbody2D body;
    private Animator animator;

    [SerializeField] private float flySpeed = 3; //constant flying speed
    [SerializeField] private float flyForce = 4; //additional flying force
    private float gravForce = 2f; //adjusted gravity
    private float scaleFactor = 0.5f; //used to resize character model | NOT USED

    private void Awake()
    {
        //Finds components for enemy Rigidbody
        body = gameObject.GetComponent<Rigidbody2D>();
        // animator = gameObject.GetComponent<Animator>();
    }

    private void Start()
    {
        // //Stop character model from rotating
        body.freezeRotation = true;

        // //Set character gravity scale to 0 while flying
        body.gravityScale = 0;
    }

    private void Update()
    {
        body.velocity = new Vector2(flySpeed*-1, body.velocity.y);
    }
}
