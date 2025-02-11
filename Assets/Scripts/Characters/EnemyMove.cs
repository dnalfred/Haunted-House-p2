using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private Rigidbody2D body;
    private Animator animator;
    private HealthController _HealthController;

    [SerializeField] private float flySpeed = 4; //constant flying speed
    private float scaleFactor = 0.5f; //used to resize character model | NOT USED
    private float direction = 1;
    private bool isTurning = false;

    [SerializeField] private float leftBoundary = 8;
    [SerializeField] private float rightBoundary = -8;
    private float minPauseTime = 0;
    private float maxPauseTime = 2;
    private float pauseTime;

    private void Awake()
    {
        //finds components for enemy Rigidbody
        body = gameObject.GetComponent<Rigidbody2D>();
        // animator = gameObject.GetComponent<Animator>();

        _HealthController = FindObjectOfType<HealthController>();
    }

    private void Start()
    {
        //stop character model from rotating
        body.freezeRotation = true;

        //set character gravity scale to 0 while flying
        body.gravityScale = 0;

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
        if(_HealthController.isInjured == false)
        {
            Fly();
        }
        else
        {
            Freeze();
        }
    }

    IEnumerator ChangeDirection()
    {
        isTurning = true;
        yield return new WaitForSeconds(pauseTime);
        direction = direction*-1; //flips direction of movement
        yield return new WaitForSeconds(0.5f);
        isTurning = false; //reset isTurning
    }

    private void Fly()
    {
        body.velocity = new Vector2(flySpeed*direction, body.velocity.y);
    }

    private void Freeze()
    {
        body.velocity = new Vector2(0, 0);
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            //remove one heart (life) from displayed hearts
           _HealthController.DeductHealth();

            //TEMP TO REMOVE
           Destroy(gameObject);
        }
    }
}
