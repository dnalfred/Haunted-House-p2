using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private Rigidbody2D body;
    private Animator animator;

    [SerializeField] private float flySpeed = 4; //constant flying speed
    private float gravForce = 2f; //adjusted gravity | NOT USED
    private float scaleFactor = 0.5f; //used to resize character model | NOT USED
    private float direction = 1;
    private bool isTurning = false;
    private float flyingHeight;

    [SerializeField] private float leftBoundary = 8;
    [SerializeField] private float rightBoundary = -8;

    private float minPauseTime = 0;
    private float maxPauseTime = 2;
    private float pauseTime;

    private Rigidbody2D otherBody;

    private void Awake()
    {
        //finds components for enemy Rigidbody
        body = gameObject.GetComponent<Rigidbody2D>();
        // animator = gameObject.GetComponent<Animator>();
    }

    private void Start()
    {
        //stop character model from rotating
        body.freezeRotation = true;

        //set character gravity scale to 0 while flying
        body.gravityScale = 0;

        flyingHeight = transform.position.y;

        pauseTime = Random.Range(minPauseTime, maxPauseTime);
        // pauseTime = Mathf.Ceil(Random.Range(minPauseTime, maxPauseTime));
        // Debug.Log(pauseTime);
    }

    private void Update()
    {
        //checks if the enemy has reached a specified boundary position
        if(!isTurning && (transform.position.x > rightBoundary || transform.position.x < leftBoundary))
        {
            StartCoroutine(ChangeDirection());
        }

        //enemy flies until it reaches a boundary or detects/hits the player
        Fly();
    }

    IEnumerator ChangeDirection()
    {
        isTurning = true;
        yield return new WaitForSeconds(pauseTime);
        direction = direction*-1; //flips direction of movement
        yield return new WaitForSeconds(0.5f);
        isTurning = false;
    }

    private void Fly()
    {
        body.velocity = new Vector2(flySpeed*direction, body.velocity.y);
    }

    private void HuntPlayer()
    {
        //this works
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
           HuntPlayer();
        }
    }
}
