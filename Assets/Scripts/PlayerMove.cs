using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D body;
    private Animator animator;
    private bool isGrounded;
    private bool onLadder;
    private bool isClimbing;

    [SerializeField] private float walkSpeed = 5; //normal walking speed
    [SerializeField] private float jumpForce = 4; //normal jumping strength
    private float gravForce = 2f; //adjusted gravity
    private float scaleFactor = 0.5f; //used to resize character model

    // Awake is called when the script is loaded
    private void Awake()
    {
        //Finds components for Player Rigidbody
        body = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        animator = GameObject.Find("Player").GetComponent<Animator>();
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
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        //Parameters for animation
        animator.SetBool("Walking", horizontalInput !=0);
        animator.SetBool("Grounded", isGrounded);

        //Set the direction of the character model
        SetDirection(horizontalInput);

        //Jumping (included here as key presses may not be detected in FixedUpdate)
        if(Input.GetKey(KeyCode.Z) && isGrounded && !onLadder)
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        //Walking
        if(isGrounded || onLadder)
        {
            Walk(horizontalInput);
        }

        //Climbing
        if(onLadder && Mathf.Abs(verticalInput) > 0f)
        {
            isClimbing = true;
        } 
        else if(onLadder && !isGrounded) //if the player lands at the top of the ladder (not isGrounded)
        {
            isClimbing = true;
        }

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

    private void Walk(float input)
    {
        body.velocity = new Vector2(input*walkSpeed, body.velocity.y);
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, jumpForce);
    }

    private void Climb(float input)
    {
        body.velocity = new Vector2(body.velocity.x, input*walkSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "ground")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "ground")
        {
            isGrounded = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "ladder")
        {
            onLadder = true;
        }
    }
    
    private void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "ladder")
        {
            onLadder = false;
            isClimbing = false;
        }
    }
}
