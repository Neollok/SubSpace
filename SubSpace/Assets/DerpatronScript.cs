using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DerpatronScript : MonoBehaviour
{

    // Use this for initialization
    public Rigidbody2D derpatron;
    public Animator derpAnimation;
    public Rigidbody2D Mob2_Projectile;

    public float speed;
    public bool shooting;
    public bool right;
    public float projectileSpeed = 6;
    
    float counter;
    int frame;
    float posx;
    float posy;

    // TODO:
    /* Make enemy aim for player
     * Make enemy shoot at the end of animaiton
    */
    void Start()
    {
        derpatron = GetComponent<Rigidbody2D>();
        derpAnimation = GetComponent<Animator>();
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

        right = flipRight;

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
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
            GameObject.Find("player").GetComponent<PlayerMovement>().playerHealth--;
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player" && counter > 0)
        {
            shooting = true;

            if (other.transform.position.x < transform.position.x) // checks if the player is to the right or left of the mob
            {
                flip(false);
            }
            else
            {
                flip(true);
            }
            posx = other.transform.position.x - transform.position.x;
            posy = other.transform.position.y - transform.position.y;

            Attack();

            counter = -0.4f;

        }
    }
    void shoot() // code that runs when shooting animation ends
    {
        Vector2 playerLocation = GameObject.Find("player").transform.position; // posision of player

        Rigidbody2D projectile;
        // spawns projectile
        

        if (right)
        {
            projectile = Instantiate(Mob2_Projectile, transform.position + new Vector3(0.08f, 0.09f, 0), transform.rotation);
            projectile.transform.localScale = new Vector3(1, 1, 1);
            projectile.velocity = new Vector2(projectileSpeed, (posx + 3 * posy - 0.1f) * 0.8f);
        }
        else
        {
            projectile = Instantiate(Mob2_Projectile, transform.position + new Vector3(-0.08f, 0.09f, 0), transform.rotation);
            projectile.transform.localScale = new Vector3(-1, 1, 1);
            projectile.velocity = new Vector2(-projectileSpeed, (-posx + 3 * posy - 0.1f) * 0.8f);
        }
    }
}
