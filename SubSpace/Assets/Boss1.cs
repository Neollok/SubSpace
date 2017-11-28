using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : MonoBehaviour {

    public int stage = 1;
    public float minTime = 5, maxTime = 8, projectileSpeed = 1, projectileSpawnTime = 1, maxSpeedModifier = 2, bossHealth = 20, bosHealthDividerStage2 = 2, speedOfRotating = 2, lengthRotating = 8, speedOfAreaDamage = 3, lengthAreaDamage = 3.5f, speedOFProjectiles = 1, lengthProjectiles = 8;

    float timer, timeLimit, currentBossHealth, mult = 0, currentSpeed;
    int currentStage, maxStage = 2;
    bool finishedAttack = false;
    // Rotating death and area damage are standard attacks, increase in speed with speed modifier based on health
    // When health goes below half maxStage goes to 3 instead of 2

	void Start () {
        currentBossHealth = bossHealth; // sets boss health to decided max health
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;

        if (finishedAttack || stage == 0) // choses another stage
        {
            //stage = Random.Range(1, maxStage); // SELECTS RANDOM VALID STAGE, currently disabled for debugging purposes

            finishedAttack = false;
        }

        if (stage == 1) // area damage
        {
            currentSpeed = speedOfAreaDamage * (1 + maxSpeedModifier * mult);
            if (timer >= lengthAreaDamage / (1 + maxSpeedModifier * mult)) // mult is 1 at 0 health and 0 at max health, maxSpeedModifier however are a value the speed of the attack changes with
            {
                finishedAttack = true;
                timer = 0;
            }
        }
        else if (stage == 2) // rotating death
        {
            currentSpeed = speedOfRotating * (1 + maxSpeedModifier * mult);
            if (timer >= lengthRotating / (1 + maxSpeedModifier * mult)) // mult is 1 at 0 health and 0 at max health, maxSpeedModifier however are a value the speed of the attack changes with
            {
                finishedAttack = true;
                timer = 0;
            }

        }
        else if (stage == 3) // bullet hell
        {
            currentSpeed = speedOFProjectiles * (1 + maxSpeedModifier * mult);
            

            if (timer >= lengthProjectiles)
            {
                finishedAttack = true;
                timer = 0;
            }
        }
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Shots") // Does not currently work all that well(as in does nothing)
        {
            currentBossHealth--;

            mult = 1 - currentBossHealth / bossHealth; // sets boss health to be based on percentage health left

            Debug.Log(currentBossHealth + ", it worked!");

            if (currentBossHealth <= bossHealth / bosHealthDividerStage2) // makes third stage accessable
                maxStage = 3;
        }
    }


}
