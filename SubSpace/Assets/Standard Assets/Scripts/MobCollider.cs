using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobCollider : MonoBehaviour {/* // floats for knockback
    public float addForceX = 5;
    public float addForceY = 5;
    public float multForceMob = 0;*/
    int mult = 1; // directional multiplier
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            GameObject player = GameObject.Find("player");
            if (GameObject.Find("player").GetComponent<PlayerMovement>().loopNotHurtRunning == false)
            {
                player.GetComponent<PlayerMovement>().playerHealth--;
                player.layer = 10;

                /* // code for knockback
                if (GetComponent<Rigidbody2D>().velocity.x < 0) 
                    mult = -1;
                else
                    mult = 1;
  
                Rigidbody2D speed = player.GetComponent<Rigidbody2D>(); // gets rigidbody of player
                speed.velocity += new Vector2(mult * (GetComponent<Rigidbody2D>().velocity.x * multForceMob + addForceX), addForceY); // Ads velocity of mob to player when colliding
                */
            }
        }
  
    }
}
