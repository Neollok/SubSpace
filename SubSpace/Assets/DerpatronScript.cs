using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DerpatronScript : MonoBehaviour
{

    // Use this for initialization
    public Rigidbody2D derpatron;
    public Animator derpAnimation;
    // public GameObject Mob2_Projectile;
    public float speed;
    public bool shooting;
    public bool right;
    float counter; // DEBUG 

    // TODO:
    /*
     * Spawn projectiles when mob is attacking
     * Make projectile(currently an empty shell)
     * Object turns when moving but not when player is within area
     * 
    */
    void Start()
    {
        derpatron = GetComponent<Rigidbody2D>();
        derpAnimation = GetComponent<Animator>();
        // Mob2_Projectile = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {

        if (counter > 2) // checks if mob is standing still
        {
            counter = 0;
            shooting = false;
            derpAnimation.SetBool("isShooting", false);
            derpAnimation.SetBool("standingStill", false);
        }

        if (!shooting) setSpeed();

        counter += Time.deltaTime; // constant timer
    }
    
    void setSpeed()
    {
        if (/*derpatron.velocity.x == 0 */derpatron.velocity.x >= -0.3 && derpatron.velocity.x <= 0.3) // Checks if it is standing still, and triggers the needed animation
        {
            derpAnimation.SetBool("standingStill", true);


            if (counter <= 0) // if speeds equals 0, reverts direction to walk
            {
                right = !right;
                counter = -1.5f;
            }
        }
        else
            derpAnimation.SetBool("standingStill", false);

        if (right)
        {
            if (derpatron.velocity.x < speed)
            {
                derpatron.velocity += new Vector2(speed, 0f);
                flip(true);
            }
        }
        else // moving right
        {
            if (derpatron.velocity.x > -speed)
            {
                derpatron.velocity += new Vector2(-speed, 0f);
                flip(false);
            }
        }


        derpAnimation.SetFloat("currentSpeed", derpatron.velocity.x * Time.deltaTime); // Updates speed bool for animations
    }
    void flip(bool flipRight) // flips the direction based on a bool
    {
        GameObject Derp_enemy = GameObject.Find("Mob2_derpatron");
        
        if (flipRight)  // right
            Derp_enemy.transform.localScale = new Vector3(1, 1, 1);
        else                           // left
            Derp_enemy.transform.localScale = new Vector3(-1, 1, 1);
    }

    void Attack()
    {
        derpAnimation.SetBool("standingStill", true);
        derpatron.velocity = new Vector2(0, derpatron.velocity.y); // makes the mob stand still when detecting the player
        derpAnimation.SetBool("isShooting", true);

        Vector2 playerLocation = GameObject.Find("player").transform.position; // posision of player
                                                                               // Debug.Log(playerLocation.x + ", " + playerLocation.y);

        /* // code for spawning object, soultion not found
        GameObject Mob2_Projectile = GameObject.Find("Mob2_Projectile");


        Instantiate(Mob2_Projectile);*/
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
            Debug.Log("Player touched the deeeerp");
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            shooting = true;

            if (counter > 0)
            {
                if (other.transform.position.x < transform.position.x) // checks if the player is to the right or left of the mob
                    flip(false);
                else
                    flip(true);
                counter = -3;

                Attack();
            }
        }
    }
}
