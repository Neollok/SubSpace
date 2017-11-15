using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Derpatron_projectile : MonoBehaviour {

    public float speed;
    public Rigidbody2D projetile;

	// Use this for initialization
	void Start () {
        projetile = GetComponent<Rigidbody2D>();
        projetile.velocity = new Vector2(speed, speed);
    }
	
	// Update is called once per frame
	void Update () {

        projetile.MoveRotation(speed* Time.deltaTime);


    }
    void OnTriggerEnter2D(Collider2D coll) // kan hende bruke OnTriggerEnter2D vil fungere, men for øyeblikket triggerer detectboxen den
    {
        if (coll.gameObject.tag == "Player")
            Debug.Log("Player touched projectile, take damage!!");
        if (coll.gameObject.tag != "Enemy" && coll.gameObject.tag != "PlayerDetection") // despawns object when it hits something that isn't an enemy
            Destroy(gameObject);
    }
}
