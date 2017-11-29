using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    //Used for most player-related mechanics. Movement, Collision detection etc. Not shooting though.
    public int maxHealth = 3;
    public int playerHealth = 3;
    private int lastHealth = 3;
    public int playerSpeed = 10;                //Player forward walking speed
    public bool dJump = false;                  //Player used doublejump?
    public bool uDown = false;                  //Player is upside down?
    public bool changeGravity = false;           //Player request to change gravity?
    public int playerJumpPower = 5;             //Player jumping power
    public float wallJumpPower = 1;
    public float maxWallSlideSpeed = 10;
    public float doubleJumpExtraPower = 1.5f;   //Players extra double jump power   
    public Vector3 currentCheckpoint;
    public bool usingThing = false;
    
    public bool grounded = true;                //Player contacting ground?
    public bool wallJumpActive = false;         //Player in position to use walljump?
    public float fallMultiplier = 2.5f;         //How fast the player gets pulled down if jump button 
                                                //is released early, allowing for a shorter jump
    
    public float lowJumpMultiplier = 2f;        //
    public float maxSpeed = 3;
    public bool onWall = false;                 //Player sticking to wall? (wall contact + holding 'a' or 'd')
    public bool rightWall = false;              //Player contacting wall on right side?
    public bool leftWall = false;               //Player contacting wall on left side?
    private Rigidbody2D rb;                     //Player rigidbody

    public float timeNotGetHurt = 1f; // Seconds player is unhurtable after losing health
    float timerNotHurt; // timer
    bool loopNotHurtRunning = false; // bool to check if player got hurt
    GameObject p;

    public AudioClip[] audioClip;               //For sound effects 

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();     //Player rigidbody assigned
        currentCheckpoint = new Vector3(PlayerPrefs.GetFloat("xCheckPoint", 0), PlayerPrefs.GetFloat("yCheckPoint", 0), 0);
        if(currentCheckpoint == new Vector3(0, 0, 0))
        {
            currentCheckpoint = GameObject.Find("SpawnPoint").transform.position;
        }
        transform.position = currentCheckpoint;
        p = GameObject.Find("player");                   // used to change layers
        
    }

    void Update()
    {
        playerHurt();


        healthCheck();

        playerMove();                                //Playermove() runs on every frame
    }

    void playerHurt() {
        if (loopNotHurtRunning)
        {
            timerNotHurt += Time.deltaTime;
            if (timerNotHurt >= timeNotGetHurt)
            {
                p.layer = 8;
                loopNotHurtRunning = false;
                timerNotHurt = 0;
            }
        }
    }

    void playerMove()
    {

        if (Input.GetKeyDown("space"))                   //If space bar pressed
        {
            if (grounded || wallJumpActive)              //If player is on the ground or is allowed to walljump
                jump();


            else if (!dJump && !onWall)                  //If player can use doublejump
            {
                doubleJump();
            }
        }

        if (Input.GetKey("e"))
            usingThing = true;
        else
            usingThing = false;

        if (Input.GetMouseButton(0))
        {
            PlaySound(0);
        }

        if (changeGravity)
        {
            flipGravity();
        }
        //if(leftWall || rightWall)
        //{
        //   if (rb.velocity.y < -maxWallSlideSpeed) 
        //        rb.velocity = new Vector2(rb.velocity.x, -maxWallSlideSpeed);
        //}
        
        if (!loopNotHurtRunning)
        {
            float move = Input.GetAxisRaw("Horizontal");
            rb.velocity += new Vector2(move * playerSpeed * Time.deltaTime, 0);

            if (rb.velocity.x > maxSpeed) rb.velocity = new Vector2(maxSpeed, rb.velocity.y);

            if (rb.velocity.x < -maxSpeed) rb.velocity = new Vector2(-maxSpeed, rb.velocity.y);


            if (grounded && move == 0)
            {

                rb.velocity = new Vector2(0, rb.velocity.y);
            }
        }
    }


    //Jump
    void jump()
    {
        grounded = false;

        if (wallJumpActive)                             //Code for a wall jump. NOT FINISHED
        {
            PlaySound(1);

            
            if(leftWall)
                rb.velocity += new Vector2(wallJumpPower, playerJumpPower * 1.3f);

            else
                rb.velocity += new Vector2(-wallJumpPower, playerJumpPower * 1.3f);

        }

        else
        {
            PlaySound(1);
            if (!uDown)
            {

                rb.velocity += new Vector2(0, playerJumpPower);

            }//Flips the jump if player is upside down


            else
            {
               // flipGravity();
                //Debug.Log("Flips the frign gravity");
            }
                
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
        if(GameObject.Find("Mag boot Effect(Clone)") != null)
        {
            Destroy(GameObject.Find("Mag boot Effect(Clone)"));
        }
        uDown = !uDown;
        changeGravity = false;

        Vector2 localScale = gameObject.transform.localScale;
        localScale.y *= -1;
        transform.localScale = localScale;

        
        rb.gravityScale *= -1;
    }

    void healthCheck()
    {
        if (playerHealth != lastHealth)
        {
            lastHealth = playerHealth;

            loopNotHurtRunning = true; // If player gets hurt, ensures their invincibility frames fires correctly
            p.layer = 10;

            if (playerHealth <= 0)
            {
                playerDie();
            }

            else
            {
                if (playerHealth == 3)
                {
                    GameObject.Find("hp1").GetComponent<RectTransform>().localScale = new Vector2(1, 1);
                    GameObject.Find("hp2").GetComponent<RectTransform>().localScale = new Vector2(1, 1);
                    GameObject.Find("hp3").GetComponent<RectTransform>().localScale = new Vector2(1, 1);
                }
                else if (playerHealth == 2)
                {
                    GameObject.Find("hp1").GetComponent<RectTransform>().localScale = new Vector2(1, 1);
                    GameObject.Find("hp2").GetComponent<RectTransform>().localScale = new Vector2(1, 1);
                    GameObject.Find("hp3").GetComponent<RectTransform>().localScale = new Vector2(0, 0);
                }
                else
                {
                    GameObject.Find("hp1").GetComponent<RectTransform>().localScale = new Vector2(1, 1);
                    GameObject.Find("hp2").GetComponent<RectTransform>().localScale = new Vector2(0, 0);
                    GameObject.Find("hp3").GetComponent<RectTransform>().localScale = new Vector2(0, 0);
                }

            }
        }
    }

    void playerDie()
    {
        GameObject.Find("hp1").GetComponent<RectTransform>().localScale = new Vector2(0, 0);
        GameObject.Find("hp2").GetComponent<RectTransform>().localScale = new Vector2(0, 0);
        GameObject.Find("hp3").GetComponent<RectTransform>().localScale = new Vector2(0, 0);

        Debug.Log("Player has died");
        //transform.position = currentCheckpoint;
        //playerHealth = maxHealth;
        float x = currentCheckpoint.x;
        float y = currentCheckpoint.y;
        PlayerPrefs.SetFloat("xCheckPoint", x);
        PlayerPrefs.SetFloat("yCheckPoint", y);
        //youPlayerPrefs.Save();
        
        Application.LoadLevel(Application.loadedLevel);
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

   
    void OnCollisionExit2D(Collision2D collision)           //Whenever player loses contact with a collision
    {
        //if (transform.position.y >= collision.gameObject.transform.position.y)
        //If the player was standing on top of the collider
        {
            if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Platform")
            {
                grounded = false;               //Counts as player not standing on ground or platform anymore
                if (uDown)
                    flipGravity();
            }
        }
    }
}
