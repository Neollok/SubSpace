using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnfallingProjectile : MonoBehaviour {
    void OnTriggerEnter2D(Collider2D coll) 
    {
        if (coll.gameObject.tag == "Player")
        {
            Debug.Log("Player touched projectile, take damage!!");
            //if(GameObject.Find("player").GetComponent<PlayerMovement>().loopNotHurtRunning == false)
                //GameObject.Find("player").GetComponent<PlayerMovement>().playerHealth--;
        }

        if (coll.gameObject.tag != "Enemy" && coll.gameObject.tag != "Boss" && coll.gameObject.tag != "PlayerDetection" && coll.gameObject.tag != "Projectile"
            && coll.gameObject.tag != "WallDetection" && !coll.CompareTag("Checkpoint") && !coll.CompareTag("Shots") && !coll.CompareTag("BossBox")) // despawns object when it hits something that isn't an enemy
            Destroy(gameObject);
    }
}
