using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flyingBall : MonoBehaviour {

    // Use this for initialization
    public float maxX = 5, minX = -5, maxY = 5, minY = -5, speed = 150, waitBetweenShots = 2, waitBeforeMovement = 1.5f, forceMultiplierShot = 140;
    public GameObject player;
    public Rigidbody2D orb;
    public Rigidbody2D projectileToShoot;
    public Animator anim;
    public bool startUp = true, startRight = true, priorityHorizontal = true;
    Vector3 playerPos;
    float posX, posY, timer;
    bool playerDetected = false, alreadyFired = false;
    float currentXPos, currentYPos;
    void Start()
    {
        anim = GetComponent<Animator>();

        if (startRight) posX = minX;
        else posX = maxX;

        if (startUp) posY = minY;
        else posY = maxY;
    }
	
	// Update is called once per frame
	void Update () {
        if (!playerDetected)
        {
            if (alreadyFired)
            {
                timer += Time.deltaTime;

                if (timer >= waitBetweenShots + waitBeforeMovement)
                {
                    alreadyFired = false;
                    timer = 0;
                }
            }

            if (timer > waitBeforeMovement || timer == 0)
                if (priorityHorizontal) // of moving horizontally
                {
                    if (startRight) // right
                    {
                        orb.velocity = new Vector2(speed * Time.deltaTime, 0);
                        posX += Time.deltaTime;
                        if (posX >= maxX)
                        {
                            priorityHorizontal = false;
                            startRight = false;
                        }
                    }
                    else // left
                    {
                        orb.velocity = new Vector2(-speed * Time.deltaTime, 0);
                        posX -= Time.deltaTime;
                        if (posX <= minX)
                        {
                            priorityHorizontal = false;
                            startRight = true;
                        }
                    }
                }
                else // if moving vertically
                {
                    if (startUp) // up
                    {
                        orb.velocity = new Vector2(0, speed * Time.deltaTime);
                        posY += Time.deltaTime;
                        if (posY >= maxY)
                        {
                            priorityHorizontal = true;
                            startUp = false;
                        }
                    }
                    else // down
                    {
                        orb.velocity = new Vector2(0, -speed * Time.deltaTime);
                        posY -= Time.deltaTime;
                        if (posY <= minY)
                        {
                            priorityHorizontal = true;
                            startUp = true;
                        }
                    }
                }
        }
    }
    void shoots()
    {
        Rigidbody2D projectile;

        projectile = Instantiate(projectileToShoot, transform.position, transform.rotation);

        projectile.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);

        projectile.AddForce(playerPos * forceMultiplierShot);
    }
    void Shoot()
    {
        shoots();
        playerDetected = false;
        alreadyFired = true;
        anim.SetBool("ballShoot", false);
    }
    void PosisionLocked() { // Locks posision of player where they are at this point in the animation
        player = GameObject.FindGameObjectWithTag("Player");
        playerPos = player.transform.position - transform.position;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (!alreadyFired && other.tag == "Player")
        {
            playerDetected = true;
            anim.SetBool("ballShoot", true);
        }
    }
}
