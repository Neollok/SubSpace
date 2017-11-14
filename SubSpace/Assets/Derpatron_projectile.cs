using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Derpatron_projectile : MonoBehaviour {

    public float speed;
    public Rigidbody2D projetile;

	// Use this for initialization
	void Start () {
        projetile = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {

        projetile.MoveRotation(speed* Time.deltaTime);


    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
            Debug.Log("Player touched projectile, take damage!!");
        if (coll.gameObject.tag == "Wall" || coll.gameObject.tag == "Roof" || coll.gameObject.tag == "floor" || coll.gameObject.tag == "Platform" || coll.gameObject.tag == "floor" || coll.gameObject.tag == "Player")
            Destroy(gameObject);
    }
}
