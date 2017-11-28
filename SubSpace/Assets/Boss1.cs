using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : MonoBehaviour {
    public Rigidbody2D projectileToShoot;
    public int stage = 1;
    public float minTime = 5, maxTime = 8, projectileSpeed = 1, projectileSpawnTime = 1, maxSpeedModifier = 2, bossHealth = 20, bosHealthDividerStage2 = 2, speedOfRotating = 2, lengthRotating = 8, speedOfAreaDamage = 3, lengthAreaDamage = 3.5f, speedOFProjectiles = 1, lengthProjectiles = 8;

    float timer, timeLimit, currentBossHealth, mult = 0, currentSpeed, tempTime;
    int currentStage, maxStage = 2, value = 0;
    bool finishedAttack = false;
    // Rotating death and area damage are standard attacks, increase in speed with speed modifier based on health
    // When health goes below half maxStage goes to 3 instead of 2
    // TO ADD: 
    /*
         - Fix to health registration so boss can lose health
         - Finish stage 2
         - Finish stage 1
         
         
         
         */
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
            currentSpeed = speedOfAreaDamage * mult;

            if (timer >= lengthAreaDamage / mult) // mult is 1 at 0 health and 0 at max health, maxSpeedModifier however are a value the speed of the attack changes with
            {
                finishedAttack = true;
                timer = 0;
            }
        }
        else if (stage == 2) // rotating death
        {
            currentSpeed = speedOfRotating * mult;

            if (timer >= lengthRotating / mult) // mult is 1 at 0 health and 0 at max health, maxSpeedModifier however are a value the speed of the attack changes with
            {
                finishedAttack = true;
                timer = 0;
            }

        }
        else if (stage == 3) // bullet hell
        {
            currentSpeed = speedOFProjectiles * mult;

            if (timer >= tempTime + 0.7)
            { shootProjectiles(); tempTime = timer; } // shoots projectiles with the speed set

            if (timer >= lengthProjectiles / mult)
            {
                finishedAttack = true;
                timer = 0;
            }
        }
    }
    void shootProjectiles()
    {
        Debug.Log(tempTime); // DEBUG
        float m = projectileSpeed * Mathf.Sqrt(2);

        if (value == 0)
        {
            value++;
            standardProjectileSpawn(projectileSpeed);
        }
        else if (value == 1)
        {
            value++;
            
            ProjectileSpawn8(m, 0.75f);
            ProjectileSpawn8(m, 0.875f);

            standardProjectileSpawn(projectileSpeed);
        }
        else if (value == 2)
        {
            value = 0;
            
            ProjectileSpawn8(m, 0.625f);
            ProjectileSpawn8(m, 0.875f);

            standardProjectileSpawn(projectileSpeed);
        }
    }

    void ProjectileSpawn8(float m, float v1)
    {
        float v2 = 1 - v1;
        v1 *= m;
        v2 *= m;

        spawnNewProjectile(v1, v2);
        spawnNewProjectile(-v1, -v2);
        spawnNewProjectile(-v1, v2);
        spawnNewProjectile(v1, -v2);
        spawnNewProjectile(v2, v1);
        spawnNewProjectile(-v2, -v1);
        spawnNewProjectile(-v2, v1);
        spawnNewProjectile(v2, -v1);

    }
    void standardProjectileSpawn(float m)
    {
        spawnNewProjectile(m, m);
        spawnNewProjectile(m, 0);
        spawnNewProjectile(0, m);

        spawnNewProjectile(-m, -m);
        spawnNewProjectile(-m, 0);
        spawnNewProjectile(0, -m);

        spawnNewProjectile(m, -m);
        spawnNewProjectile(-m, m);
    }
    void spawnNewProjectile(float x, float y)
    {
        Rigidbody2D projectile;

        projectile = Instantiate(projectileToShoot, transform.position + new Vector3(0, 0, 0), transform.rotation);
        projectile.transform.localScale = new Vector3(1, 1, 1);
        projectile.velocity = new Vector2(projectileSpeed * x, projectileSpeed * y);

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
