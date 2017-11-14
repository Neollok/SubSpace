using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DerpatronScript : MonoBehaviour {

    // Use this for initialization
    public Rigidbody2D derpatron;
    public Animator derpAnimation;
    public float speed;
    public bool shooting;
    public bool right;
    float counter; // DEBUG 

    // TODO:
    /*
     * Spawn projectiles when mob is attacking
     * Make checks fo player be not when the player impacts the sircle, but when they stay there
     * Make checktime longer
     * Make projectile(currently an empty shell)
     * 
     * 
    */
    void Start () {
        derpatron = GetComponent<Rigidbody2D>();
        derpAnimation = GetComponent<Animator>();
        setSpeed();
    }
	
	// Update is called once per frame
	void Update () {
        AI();
    }

    void AI() // sets speed or attacks
    {
        if (shooting)
            Attack();
        else
            setSpeed();

    }
    void setSpeed()
    {
        if (derpatron.velocity.x == 0 /*derpatron.velocity.x >= -0.1 && derpatron.velocity.x <= 0.1*/) // Checks if it is standing still, and triggers the needed animation
        {
            derpAnimation.SetBool("standingStill", true);
            if (counter == 0)
            {
                right = !right;
                counter = 150;
                Debug.Log(right);
            }
            else
                counter--;
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
    void flip(bool flipRight)
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
        counter += Time.deltaTime;
        if (counter > 50000 * Time.deltaTime) // timer so it stops attacking after a little while
        {
            derpAnimation.SetBool("isShooting", false);
            shooting = false;
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
            Debug.Log("Player touched the deeeerp");
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            shooting = true;

            Debug.Log("Player!");

            if (right && other.transform.position.x < transform.position.x) // checks if the player is to the right of the mob
            {
                flip(true);
            }
        }
    }
}
