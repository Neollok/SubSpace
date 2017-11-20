using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForGround : MonoBehaviour {

    public PlayerMovement pm;
        private void Start()
    {
        pm = GameObject.Find("player").GetComponent<PlayerMovement>();
    }
    void OnTriggerEnter2D(Collider2D collision)            //Whenever player first collides with a collision
    {
       
        // if (transform.position.y >= collision.gameObject.transform.position.y)    //If player is standing above the object
        {

            if (collision.gameObject.tag == "Ground"
                || collision.gameObject.tag == "Platform") //If the collision has 'Ground' or 'Platform' as tag
            {
                
                pm.grounded = true;                        //"Resets" player jump related bools
                pm.dJump = false;
                pm.changeGravity = false;                   //Allows the player to change gravity again.
                                                            //Will probably be removed.
                GameObject.Find("player").GetComponent<RayCast>().canChange = true;
            }
        }
    }
}
