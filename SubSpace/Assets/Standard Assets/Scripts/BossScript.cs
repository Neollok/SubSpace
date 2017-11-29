using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour {
    public Rigidbody2D projectileToShoot;
    public int stage = 1, bossHealth = 20, currentBossHealth;
    public float minTime = 5, maxTime = 8, projectileSpeed = 150, projectileSpawnTime = 1, maxSpeedModifier = 2, bosHealthDividerStage2 = 2, speedOfRotating = 2, lengthRotating = 8, lengthAreaDamage = 3.5f, lengthProjectiles = 8, stage3LengthBetweenShots = 0.6f, incDegRotPerPro = 1, waitBetweenStages = 1;
    float timer, timeLimit, mult = 1, currentSpeed, tempTime, currentPosX = 0.725f, currentPosY = -0.257f, currentDegrees;
    int currentStage, maxStage = 3, value = 0, previousHealth;
    bool finishedAttack = false;
    // Rotating death and area damage are standard attacks, increase in speed with speed modifier based on health
    // When health goes below half maxStage goes to 3 instead of 2
    // TO ADD: 
    /*
         - Finish stage 1
         - Modify modifier so it changes at 75%, 50% and 25% health
         */
	void Start () {
        currentBossHealth = bossHealth; // sets boss health to decided max health
        currentSpeed = projectileSpeed;
    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;

        if (previousHealth != currentBossHealth) // Boss have taken damage
        {
            previousHealth = currentBossHealth;
            
            Debug.Log(currentBossHealth + ", it worked!");

            if (currentBossHealth <= bossHealth * 0.25) // if at 25% health
            {
                mult = 1 + (maxSpeedModifier - 1);
            }
            else if (currentBossHealth <= bossHealth * 0.5) // if at 50% health
            {
                mult = 1 + (maxSpeedModifier - 1) * 0.5f;
            }
            else if (currentBossHealth <= bossHealth * 0.75) // if at 75% health
            {
                mult = 1 + (maxSpeedModifier - 1) * 0.25f;
            }

            currentSpeed = mult * projectileSpeed;

            if (currentBossHealth <= bossHealth / bosHealthDividerStage2) // makes third stage accessable
                maxStage = 3;
        }


        if (finishedAttack || stage == 0) // choses another stage
        {
            stage = 4; // SELECTS RANDOM VALID STAGE, currently disabled for debugging purposes
            finishedAttack = false;
        }

        if (stage == 1) // area damage
        {


            if (timer >= lengthAreaDamage) // mult is 1 at 0 health and 0 at max health, maxSpeedModifier however are a value the speed of the attack changes with
            {
                finishedAttack = true;
                timer = 0;
            }
        }
        else if (stage == 2) // rotating death
        {   
            if (timer >= tempTime + 0.08f / mult || timer == 0)
            { LaserBeam(); tempTime = timer; } // shoots projectiles with the speed set

            if (timer >= lengthRotating) // mult is 1 at 0 health and 0 at max health, maxSpeedModifier however are a value the speed of the attack changes with
            {
                finishedAttack = true;
                currentPosX = 0.275f; // resets these values so it starts  at normal location
                currentPosY = -0.257f;
                timer = 0;
            }

        }
        else if (stage == 3) // bullet hell
        {
            if (timer >= tempTime + stage3LengthBetweenShots / mult)
            { shootProjectiles(); tempTime = timer; } // shoots projectiles with the speed set

            if (timer >= lengthProjectiles)
            {
                finishedAttack = true;
                timer = 0;
            }
        }
        else // code for when boss waits between stages
        {
            if (timer >= waitBetweenStages) // chooses next stage
            {
                Debug.Log(stage + ", " + tempTime + ", " + maxStage); // Works, gives a number(might not be very random)
                tempTime = 0;

                stage = Random.Range(2, maxStage + 1);
            }
        }
    }
    void LaserBeam()
    {
        spawnNewProjectile(currentDegrees, currentPosX, currentPosY);
        spawnNewProjectile(currentDegrees + 120, currentPosX, currentPosY);
        spawnNewProjectile(currentDegrees - 120, currentPosX, currentPosY);
        currentDegrees += incDegRotPerPro;
    }
    void shootProjectiles()
    {
         // DEBUG
        if (value == 0)
        {
            value++;

            ProjectileSpawn8(0);
            ProjectileSpawn8(75);
            ProjectileSpawn8(15);

        }
        else if (value == 1)
        {
            value++;

            ProjectileSpawn8(22.5f);
            ProjectileSpawn8(11.25f);
            ProjectileSpawn8(33.75f);
        }
        else if (value == 2)
        {
            value++;

            ProjectileSpawn8(0);
            ProjectileSpawn8(60f);
            ProjectileSpawn8(30f);
        }
        else if (value == 3)
        {
            value++;

            ProjectileSpawn8(60);
            ProjectileSpawn8(120);
            ProjectileSpawn8(11.25f);
            ProjectileSpawn8(33.75f);
        }
        else if (value == 5)
        {
            value++;

            ProjectileSpawn8(0);
            ProjectileSpawn8(9);
            ProjectileSpawn8(36);
        }
        else if (value == 6)
        {
            value++;

            ProjectileSpawn8(9);
            ProjectileSpawn8(18);
            ProjectileSpawn8(27);
            ProjectileSpawn8(36);
            ProjectileSpawn8(45);
        }
        else if (value == 7)
        {
            value++;


            ProjectileSpawn8(0);
            ProjectileSpawn8(35);
            ProjectileSpawn8(10);
        }
        else if (value == 8)
        {
            value++;
            
            ProjectileSpawn8(22.5f);
            ProjectileSpawn8(45);
            ProjectileSpawn8(0);
            ProjectileSpawn8(11.25f);
            ProjectileSpawn8(33.75f);
        }
        else
        {
            value = 0;
            ProjectileSpawn8(65);
            ProjectileSpawn8(25);
            ProjectileSpawn8(9);
            ProjectileSpawn8(36);
            ProjectileSpawn8(60);
            ProjectileSpawn8(30);
            ProjectileSpawn8(22.5f);
            ProjectileSpawn8(11.25f);
            ProjectileSpawn8(33.75f);
        }
    }

    void ProjectileSpawn8(float degrees)
    {
        spawnNewProjectile(degrees);
        spawnNewProjectile(degrees + 45);
        spawnNewProjectile(degrees + 90);
        spawnNewProjectile(degrees + 135);
        spawnNewProjectile(degrees + 180);
        spawnNewProjectile(degrees + 225);
        spawnNewProjectile(degrees + 270);
        spawnNewProjectile(degrees + 315);

    }
    void spawnNewProjectile(float degrees, float xPos = 0.275f, float yPos = -0.257f)
    {
        Rigidbody2D projectile;
        
        projectile = Instantiate(projectileToShoot, transform.position + new Vector3(xPos, yPos, 0), transform.rotation);
        projectile.transform.localScale = new Vector3(1, 1, 1);

        Vector3 dir = Quaternion.AngleAxis(degrees, Vector3.forward) * Vector3.right;
        projectile.AddForce(dir * currentSpeed);

    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Shots") // Does not currently work all that well(as in does nothing)
        {
            currentBossHealth--;

            mult = 1 + (maxSpeedModifier - 1) * (1 - currentBossHealth / bossHealth); // sets boss speed modifier to be based on percentage health left

            Debug.Log(currentBossHealth + ", it worked!");

            if (currentBossHealth <= bossHealth / bosHealthDividerStage2) // makes third stage accessable
                maxStage = 3;
        }
    }
}
