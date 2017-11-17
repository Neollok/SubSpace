using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Derpatron_projectile : MonoBehaviour {

    //public float speedX, speedY;
    public Rigidbody2D projectile;

	// Use this for initialization
	void Start () {
        projectile = GetComponent<Rigidbody2D>();
        //projetile.velocity = new Vector2(speedX, speedY);
    }
	
	// Update is called once per frame
	void Update () { // Code for projectile rotation
        Vector2 dir = projectile.velocity;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);

        if (projectile.transform.localScale.x == -1)
            projectile.transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 90 * Time.deltaTime);
        else
            projectile.transform.rotation = Quaternion.RotateTowards(transform.rotation, q, -90 * Time.deltaTime);

    }
    void OnTriggerEnter2D(Collider2D coll) // kan hende bruke OnTriggerEnter2D vil fungere, men for øyeblikket triggerer detectboxen den
    {
        if (coll.gameObject.tag == "Player")
        {
            Debug.Log("Player touched projectile, take damage!!");
            GameObject.Find("player").GetComponent<PlayerMovement>().playerHealth--;
        }
            
        if (coll.gameObject.tag != "Enemy" && coll.gameObject.tag != "PlayerDetection" && coll.gameObject.tag != "Projectile"
            && coll.gameObject.tag != "WallDetection" && !coll.CompareTag("Checkpoint")) // despawns object when it hits something that isn't an enemy
            Destroy(gameObject);
    }
}
