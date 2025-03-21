using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private PlayerData playerData;
    private GameController gameController;
    private GameObject player;

    private Rigidbody2D body;
    private Animator animator;

    private float direction = 1;
    [SerializeField] private float flySpeed = 4; //regular flying speed
    private float flySpeedY = 0; //regular vertical flying speed
    private float scaleFactor = 1.2f; //used to resize character model
    private bool isTurning = false;
    private bool isHunting = false;
    private bool stoppedHunting = true;
    private float startHeight;

    [SerializeField] private float leftBoundary = 2;
    [SerializeField] private float rightBoundary = -2;
    private float minPauseTime = 0;
    private float maxPauseTime = 2;
    private float pauseTime;

    #region AWAKE, START & UPDATE
    private void Awake()
    {
        //Finds components for enemy Rigidbody
        body = gameObject.GetComponent<Rigidbody2D>();
        // animator = gameObject.GetComponent<Animator>();

        //Finds playerdata object
        playerData = FindObjectOfType<PlayerData>();

        //Finds the player game object
        player = GameObject.Find("Player");
    }

    private void Start()
    {
        //Stop character model from rotating
        body.freezeRotation = true;

        //Set character gravity scale to 0 while flying
        body.gravityScale = 0;

        //Set pause time for each enemy to turn
        pauseTime = Random.Range(minPauseTime, maxPauseTime);

        //Set the height (y position) of the game object
        startHeight = body.transform.position.y;
    }

    private void Update()
    {
        //Checks if the enemy has reached a specified boundary position
        if(!isTurning && (transform.position.x > rightBoundary || transform.position.x < leftBoundary))
        {
            StartCoroutine(ChangeDirection());
        }

        //Set the direction the character sprite is facing
        SetDirection();

        //After game starts, enemy flies until it reaches a boundary or detects/hits the player
        if(playerData.isLevelStart == 1 || playerData.isInjured || playerData.isLevelEnd == 1)
        {
            Freeze();
        }
        else
        {
            Fly();
        }

        if(isHunting)
        {
            HuntPlayer();
        }

        if(stoppedHunting)
        {
            CheckHeight();
        }
    }
    #endregion

    #region REGULAR MOVEMENT
    //Change direction of movement when triggered
    IEnumerator ChangeDirection()
    {
        isTurning = true;
        yield return new WaitForSeconds(pauseTime);
        direction = direction*-1; //flips direction of movement
        yield return new WaitForSeconds(0.5f);
        isTurning = false; //reset isTurning
    }

    //Set direction of the character sprite
    private void SetDirection()
    {
        if(direction > 0.0f)
        {
            transform.localScale = new Vector3(scaleFactor, scaleFactor, scaleFactor);
        }
        else
        {
            transform.localScale = new Vector3(-scaleFactor, scaleFactor, scaleFactor);
        }
    }

    //Stop enemy from moving
    private void Freeze()
    {
        body.velocity = new Vector2(0, 0);
    }

    //Move enemy (regular patrolling movement)
    private void Fly()
    {
        body.velocity = new Vector2(flySpeed*direction, flySpeedY);
    }
    #endregion

    #region SPECIAL MOVEMENT
    //Move enemy towards player object
    private void HuntPlayer()
    {
        stoppedHunting = false;
        float playerX = player.transform.position.x; 
        float playerY = player.transform.position.y;
        float enemyX = body.transform.position.x;
        float enemyY = body.transform.position.y;
        if(playerX > enemyX)
        {
            direction = 1;
        }
        else
        {
            direction = -1;
        }
        if(playerY > enemyY)
        {
            flySpeedY = flySpeed;
        }
        else
        {
            flySpeedY = -flySpeed;
        }
    }

    //Return emeny to starting height
    private void CheckHeight()
    {
        if(transform.position.y > startHeight)
        {
            flySpeedY = -flySpeed;
        }
        else if(transform.position.y < startHeight)
        {
            flySpeedY = flySpeed;
        }
        else
        {
            flySpeedY = 0;
            stoppedHunting = false;
        }
    }

    //Slows down enemy when triggered
    public void SlowedFlying()
    {
        StartCoroutine(Slowed());
    }

    //Corountine to slow down an enemy
    IEnumerator Slowed()
    {
        float currentSpeed = flySpeed;
        flySpeed = flySpeed/2;
        yield return new WaitForSeconds(8);
        flySpeed = currentSpeed;
    }
    #endregion

    #region COLLISIONS WITH ENEMY TRIGGER COLLIDER
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            //Set isHunting variable to start hunting
            isHunting = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            //Set isHunting variable to stop hunting
            isHunting = false;
            stoppedHunting = true;
        }
    }
    #endregion

    #region COLLISIONS WITH ENEMY GAME OBJECT
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            //Deduct one health point / heart from the player
            playerData.DeductHealth();
        }
    }
    #endregion
}
