using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    //Used for most player-related mechanics. Movement, Collision detection etc. Not shooting though.


    public int playerSpeed = 10;                //Player forward walking speed
    public bool dJump = false;                  //Player used doublejump?
    public bool uDown = false;                  //Player is upside down?
    public bool changeGravity = true;           //Player request to change gravity?
    public int playerJumpPower = 5;             //Player jumping power
    public float wallJumpPower = 1;
    public float maxWallSlideSpeed = 10;
    public float doubleJumpExtraPower = 1.5f;   //Players extra double jump power    
    public float moveX;                         //Player facing direction (1 || -1)
    public bool grounded = true;                //Player contacting ground?
    public bool wallJumpActive = false;         //Player in position to use walljump?
    public float fallMultiplier = 2.5f;         //How fast the player gets pulled down if jump button 
                                                //is released early, allowing for a shorter jump
    public float lowJumpMultiplier = 2f;        //
    public bool onWall = false;                 //Player sticking to wall? (wall contact + holding 'a' or 'd')
    public bool rightWall = false;              //Player contacting wall on right side?
    public bool leftWall = false;               //Player contacting wall on left side?
    private Rigidbody2D rb;                     //Player rigidbody
    public float wjTime = 0.5f;
    private float cTime = 0.5f;
    private bool wallJumping;
   

    public AudioClip[] audioClip;               //For sound effects 

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();     //Player rigidbody assigned
    }

    void Update()
    {
 
        playerMove();                                //Playermove() runs on every frame
    }

    void playerMove()
    {

        moveX = Input.GetAxis("Horizontal");            //Horizontal direction to the players
        
        
        if (Input.GetKeyDown("space"))                   //If space bar pressed
        {
            if (grounded || wallJumpActive)              //If player is on the ground or is allowed to walljump
                jump();

           
            else if (!dJump && !onWall)                  //If player can use doublejump
            {
                doubleJump();
            }
        }


        if (Input.GetKeyDown("q"))                       //Flips gravity with q-press. Will be changed
        {
            if (changeGravity)
                flipGravity();
        }
        
        if (Input.GetKeyDown("f"))                       //Unused
        {
            
        }
        if(Input.GetMouseButton(0))
        {
            PlaySound(0);
        }
       

        if(leftWall || rightWall)
        {
            if (rb.velocity.y < -maxWallSlideSpeed) 
                rb.velocity = new Vector2(rb.velocity.x, -maxWallSlideSpeed * Time.deltaTime);
        }
      
        if(wallJumping)
        {
            rb.velocity = new Vector2(1 * Time.deltaTime * wallJumpPower, rb.velocity.y);
            cTime -= Time.deltaTime;
            if(cTime <= 0)
            {
                wallJumping = false;
                cTime = wjTime;
            }
            rb.velocity += new Vector2((moveX * Time.deltaTime * playerSpeed)/3, 0);
        }
        else
        rb.velocity = new Vector2(moveX * Time.deltaTime * playerSpeed, rb.velocity.y);    //Moves player by 'playerSpeed'
        
        

    }


    //Jump
    void jump()
    {

        if (wallJumpActive)                             //Code for a wall jump. NOT FINISHED
        {
            PlaySound(1);

            wallJumping = true;

            rb.velocity = Vector2.up * playerJumpPower;

        }

        else
        {
            PlaySound(1);
            if (!uDown)
            {
                rb.velocity = Vector2.up * playerJumpPower;
                Debug.Log("Normal jump");
            }//Flips the jump if player is upside down
                

            else

                rb.velocity = Vector2.up * playerJumpPower * -1;
        }
    }

    void doubleJump()
    {
        PlaySound(2);
        dJump = true;
        rb.velocity = Vector2.up * playerJumpPower * doubleJumpExtraPower;      //Jumping power * extra power
    }




    void flipGravity()          //Flips gravity and player. 
    {
        uDown = !uDown;
        changeGravity = false;

        Vector2 localScale = gameObject.transform.localScale;
        localScale.y *= -1;
        transform.localScale = localScale;

        rb.gravityScale *= -1;
    }

    //Sound

    void PlaySound(int clip)
    {
        AudioSource audio = GetComponent<AudioSource>();
        if (clip == 0)
        {
            audio.pitch = 1.5f;
        }
        else
        {
            audio.pitch = 1;
        }
        audio.clip = audioClip[clip];
        audio.Play();
    }



    //Collisions

    void OnCollisionEnter2D(Collision2D collision)            //Whenever player first collides with a collision
    {
        if (transform.position.y >= collision.gameObject.transform.position.y)    //If player is standing above the object
        {

            if (collision.gameObject.tag == "Ground"
                || collision.gameObject.tag == "Platform") //If the collision has 'Ground' or 'Platform' as tag
            {

                grounded = true;                        //"Resets" player jump related bools
                dJump = false;
                changeGravity = true;                   //Allows the player to change gravity again.
                                                        //Will probably be removed.
            }
        }
    }
    void OnCollisionExit2D(Collision2D collision)           //Whenever player loses contact with a collision
    {
        if (transform.position.y >= collision.gameObject.transform.position.y)
        //If the player was standing on top of the collider
        {
            if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Platform")
            {
                grounded = false;               //Counts as player not standing on ground or platform anymore
            }
        }
    }
}
