using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailCollision : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string tag = collision.transform.tag;
        if (tag != "Player" && tag != "Arm" && tag != "WallDetection")
        Destroy(gameObject);
        if(tag == "Enemy")
        {
            Destroy(collision.gameObject);
        }
    }
}
