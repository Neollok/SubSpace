using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour {
    float posX, posY;
    Rigidbody2D jumper;
    Animator jumperAnimation;
    GameObject jumper_enemy;

    public float jumperSpeed = 8;
    public float wait = 0;
    bool inAir = false;
    bool right;
    bool codeHaveTriggered = false;
    float timer;
    int mult;

	// Use this for initialization
	void Start ()
    {
        jumper = GetComponent<Rigidbody2D>();
        jumperAnimation = GetComponent<Animator>();
        jumper_enemy = GameObject.Find("Jumper");
    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;

        right = posX > 0;
        
        if (right)
            mult = 1;
        else
            mult = -1;

        jumper_enemy.transform.localScale = new Vector3(mult, 1, 1);

        if (inAir) // are in the air
        {
            if (!codeHaveTriggered) // code to run once in the beginning of jump
            {
                jumper.velocity += new Vector2(mult * jumperSpeed, 1.5f);
                codeHaveTriggered = true;
                jumperAnimation.SetBool("Jumping", true);
            }

            if (jumper.velocity.y == 0) inAir = false;// sets inAir to false when landing
        }
        else // are on the ground
        {
            if (codeHaveTriggered)
            {
                codeHaveTriggered = false;
                jumperAnimation.SetBool("Jumping", false);
                inAir = false;
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
