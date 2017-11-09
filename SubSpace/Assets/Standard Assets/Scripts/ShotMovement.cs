using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotMovement : MonoBehaviour {

    //Pretty sure this is unused. Don't know if it will be needed.

    public GameObject player;
    public float speed;
    private int pos1 = -1;
    private int pos2 = -1;
    

    void Start ()
    {
        Debug.Log("DDD");
        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
        float force = Random.value;
        transform.Rotate(0, 0, 140);
        rb.AddForce(transform.forward*speed, ForceMode2D.Impulse);
    }
	
	
	void Update () {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag != "Enemy")
        Destroy(gameObject);
    }
}
