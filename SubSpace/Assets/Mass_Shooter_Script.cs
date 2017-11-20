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

        if (playerDetected && (int)counter != previousInt)
        {
            previousInt = (int)counter;
            Active();
        }

        if (counter > timeUnit)
            playerDetected = false;

        counter += Time.deltaTime;
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerDetected = true;
        }
    }
    void Active() // code to shoot projectiles randomly
    {
        Rigidbody2D newProjectile;
        int rand = Random.Range(0, 2);
        rand = rand == 1 ? Random.Range(2, 3) : Random.Range(-3 , -2);

        Vector3 temp = transform.rotation.eulerAngles; // needed code to modify degrees of shot

        newProjectile = Instantiate(projectile, simple_Shooter.transform.position - new Vector3(0, 0.2f, 0), Quaternion.Euler(temp));                                               //temp.z -= 0;

        if (rand > 0)
        {
            temp.z += 10; // degrees to add to shot
            newProjectile.transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            temp.z += 45;
            newProjectile.transform.localScale = new Vector3(-1, 1, 1);
        }

        newProjectile.velocity = new Vector2(rand, Random.Range(7, 9));
    }
}
