using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private PlayerData playerData;
    private Rigidbody2D body;
    private Animator animator;

    private bool onGround;
    private bool onLadder;
    private bool isClimbing;
    private bool isGrounded;
    private bool isFallingOff = false;

    [SerializeField] private float walkSpeed = 5; //normal walking speed
    [SerializeField] private float jumpForce = 4; //normal jumping strength
    private float gravForce = 2f; //adjusted gravity
    private float scaleFactor = 0.5f; //used to resize character model

    #region AWAKE, START & UPDATES

    // Awake is called when the script is loaded
    private void Awake()
    {
        //Finds components for Player Rigidbody
        body = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();

        playerData = FindObjectOfType<PlayerData>();
    }

    // Start is called before the first frame update
    private void Start()
    {
        //Stop character model from rotating
        body.freezeRotation = true;

        //Set character gravity scale to adjusted value
        body.gravityScale = gravForce;
    }

    // Update is called once per frame
    void Update()
    {

        if(playerData.isInjured && !isFallingOff)
        {
            // isFallingOff = true;
            // FallOffScreen();
        }

        float horizontalInput = Input.GetAxis("Horizontal");

        //Parameters for animation
        animator.SetBool("Walking", horizontalInput !=0);
        animator.SetBool("Grounded", isGrounded);

        //Set the direction of the character model
        if(Mathf.Abs(horizontalInput) > 0f)
        {
            SetDirection(horizontalInput);
        }
    }

    private void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        //walking
        if(onGround || onLadder)
        {
            Walk(horizontalInput);
        }

        //jumping
        if(Input.GetKey(KeyCode.UpArrow) && onGround && !onLadder)
        {
            Jump();
        }

        //sets isClimbing value
        if(onLadder && Mathf.Abs(verticalInput) > 0f)
        {
            isClimbing = true;
        }
        else if(onLadder && !onGround) //if the player lands at the top of the ladder (not onGround)
        {
            isClimbing = true;
            isGrounded = true;
        }

        //climbing
        if(isClimbing)
        {
            body.gravityScale = 0f;
            body.velocity = new Vector2(body.velocity.x, verticalInput*walkSpeed);
        }
        else
        {
            body.gravityScale = gravForce;
        }
    }

    #endregion

    #region SET PLAYER DIRECTION

    //function to set the direction the player's character model is facing
    private void SetDirection(float input)
    {
        if(input > 0.0f)
        {
            transform.localScale = new Vector3(scaleFactor, scaleFactor, scaleFactor);
        }
        else if(input < 0.0f)
        {
            transform.localScale = new Vector3(-scaleFactor, scaleFactor, scaleFactor);
        }
    }

    #endregion

    #region MOVEMENT

    private void Walk(float input)
    {
        body.velocity = new Vector2(input*walkSpeed, body.velocity.y);
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, jumpForce);
    }

    private void FallOffScreen()
    {
        body.velocity = new Vector2(0, jumpForce*2);
        body.GetComponent<Collider2D>().enabled = false;
    }

    #endregion

    #region COLLISION DETECTION

    //function to detect collisions with ground objects
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "ground")
        {
            onGround = true;
            isGrounded = true;
        }
    }

    //function to detect if collision with ground object has ceased
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "ground")
        {
            onGround = false;
            isGrounded = false;
        }
    }

    //function to detect collision with ladder objects (trigger)
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "ladder")
        {
            onLadder = true;
            isGrounded = true;
        }
    }
    
    //function to detect of collision with ladder objects (trigger) has ceased
    private void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "ladder")
        {
            onLadder = false;
            isClimbing = false;
        }
    }

    #endregion

    #region WHEN NOT VISIBLE

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
        Debug.Log("Player object destroyed at y = " + transform.position.y);
    }

    #endregion
}
