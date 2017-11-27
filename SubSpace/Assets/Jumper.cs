using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour {
    float posX, posY;
    Rigidbody2D jumper;
    Animator jumperAnimation;
    GameObject jumper_enemy;
    BoxCollider2D hitBox;


    public float jumpHeight = 1.5f, jumperSpeed = 8, minWait = 0, maxWait = 0;
    bool inAir = false;
    bool right;
    bool codeHaveTriggered = false;
    float timer, wait;
    int mult;

    // TODO
    /*
     * Make mob involnurable while still
     * Modify hitbox of mob
     */
	void Start ()
    {
        jumper = GetComponent<Rigidbody2D>();
        jumperAnimation = GetComponent<Animator>();
        hitBox = GetComponent<BoxCollider2D>();
    }
	
	// Update is called once per frame
	void Update () {
        right = posX > 0;
        
        if (right)
            mult = 1;
        else
            mult = -1;



        if (inAir) // are in the air
        {
            if (timer >= wait)
            {
                wait = Random.Range(minWait, maxWait);

                transform.localScale = new Vector3(mult, 1, 1);
                //jumper_enemy.transform.localScale = new Vector3(mult, 1, 1);

                if (!codeHaveTriggered) // code to run once in the beginning of jump
                {
                    jumper.velocity += new Vector2(mult * jumperSpeed, jumpHeight);
                    codeHaveTriggered = true;
                    jumperAnimation.SetBool("Jumping", true);
                    hitBox.size = new Vector2(hitBox.size.x, 0.7f);
                    hitBox.offset = new Vector2(hitBox.offset.x, -0.1f);
                }
                timer = 0;
            }

            if (jumper.velocity.y == 0) inAir = false;// sets inAir to false when landing
            timer += Time.deltaTime;
        }
        else // are on the ground
        {
            if (codeHaveTriggered)
            {
                codeHaveTriggered = false;
                jumperAnimation.SetBool("Jumping", false);
                inAir = false;
                hitBox.size = new Vector2(hitBox.size.x, 0.35f);
                hitBox.offset = new Vector2(hitBox.offset.x, -0.3f);
            }
        }


    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            posX = other.transform.position.x - transform.position.x;
            inAir = true;
        }
    }
}
