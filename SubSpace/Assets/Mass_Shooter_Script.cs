using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mass_Shooter_Script : MonoBehaviour
{
    bool playerDetected;
    int previousInt;
    float counter, posx, posy;
    Rigidbody2D simple_Shooter;
    public Rigidbody2D projectile;
    public float massShooterSpeed = 1; 
    public float timeUnit = 1;
    public float minY = 7, maxY = 10, minX = 1, maxX = 4;
    public int NrProjectilesmin = 2, NrProjectilesMax = 5;
    // Use this for initialization
    void Start()
    {
        simple_Shooter = GetComponent<Rigidbody2D>();
    }
    // Bug: it somehow moves slowly right, should not be the case
    // Update is called once per frame
    void Update()
    {

        // code that handles movement, may be modified if movement is wished while shooting(timeUnit is all that needs to be modified)

        if (counter >= timeUnit && counter < 2 * timeUnit && simple_Shooter.velocity.y == 0)
            simple_Shooter.velocity = new Vector2(massShooterSpeed * Time.deltaTime, simple_Shooter.velocity.y);
        else if (counter >= 2 * timeUnit && counter < 3 * timeUnit && simple_Shooter.velocity.y == 0)
            simple_Shooter.velocity = new Vector2(-massShooterSpeed * Time.deltaTime, simple_Shooter.velocity.y);
        else if (counter >= 3 * timeUnit)
            counter = 1;
        
        if (/*playerDetected && */(int)counter != previousInt)
        {
            previousInt = (int)counter;
            Active();
        }
        counter += Time.deltaTime;
    }
    /*void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerDetected = true;
        }
    }*/
    void Active() // code to shoot projectiles randomly
    {/*
        SpawnProjectle(10, 1, 1);
        SpawnProjectle(-10, -1, 2);
        SpawnProjectle(10, 1, 1);
        SpawnProjectle(-10, -1, 2);*/
        for (int I = 0; I < Random.Range(NrProjectilesmin, NrProjectilesMax); I++)
        {
            if (Random.Range(1, 10) > 5) SpawnProjectle(10, 1, 1);
            else SpawnProjectle(-10, -1, 2);
        }


    }

    void SpawnProjectle(int z, int localscale, float type)
    {
        type = type == 1 ? Random.Range(minX, maxX) : Random.Range(-maxX, -minX);

        Vector3 temp = transform.rotation.eulerAngles; // needed code to modify degrees of shot
        temp.z += z;

        Rigidbody2D newProjectile;

        newProjectile = Instantiate(projectile, simple_Shooter.transform.position - new Vector3(0, 0.2f, 0), Quaternion.Euler(temp));
        newProjectile.transform.localScale = new Vector3(localscale, 1, 1);
        newProjectile.velocity = new Vector2(type, Random.Range(minY, maxY));
    }
}
