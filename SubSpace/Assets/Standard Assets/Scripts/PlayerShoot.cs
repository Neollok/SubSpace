using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    //This script only creates an instance of the bullet in the correct position. 
    //The prefab itself has instructions on how to behave (move)

    public Transform bulletTrailPrefab;         //Shooting prefab used to make the bullets
    public float fireRate;                      //Cooldown for shooting
    public float Damage;                        //Damage for the bullet
    public LayerMask whatNotToHit;                 //Which layers the bullet can interact with (i.e. ignore background)

    float timeToFire = 0;
    Transform firePoint;

    void Start()
    {
      
            firePoint = transform.Find("shootingPoint");       //There is an object on the tip of the weapon
                                                                //from where the bullets will start
        if(firePoint == null)                                   
        {
            Debug.LogError("Can't find child object 'shootingPoint'");
        }
    }

    void Update()
    {
        
        if(fireRate == 0)                           //If no cooldown for shooting
        {
            if(Input.GetButton("Fire1"))        //Left mouse button
            {
                Shoot();
            }
        }
    }
    void Shoot()
    {

        Vector2 mousePos = new Vector2(
            Camera.main.ScreenToWorldPoint(Input.mousePosition).x, 
            Camera.main.ScreenToWorldPoint(Input.mousePosition).y);     //Mouse position in game in a vector2
                                                                      

        Vector2 firePointPos = new Vector2(
            firePoint.position.x, 
            firePoint.position.y);   //Position of firing point also in a vector2

        //If the mouse X position - the player position is less than 0
        if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x - GameObject.Find("player").transform.position.x < 0)
        {
          
                        //Then we want the bullets to move the opposite direction as well
        }

        //This ray is a straight invisible beam from fire position to (mouse position-fire position)
        //100 is the distance (not important). whatToHit is what layers to interact with
        RaycastHit2D hit = Physics2D.Raycast(firePointPos, mousePos - firePointPos, 100, whatNotToHit);

        Effect();                                   //Runs the function that creates an instance of a bullet

        Debug.DrawLine(firePointPos, (mousePos-firePointPos)*100);     //Used for debugging. can see the bullets ray
        if(hit.collider != null)
        {
            Debug.DrawLine(firePointPos, hit.point, Color.red);
        }
    }
    void Effect()
    {
        Instantiate(bulletTrailPrefab, firePoint.position, firePoint.rotation); //Instantiates of the prefab to the actual game   
    }
}
