﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailCollision : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string tag = collision.transform.tag;
        if (tag != "Player" && tag != "Arm" && tag != "Checkpoint" && tag != "WallDetection" && tag != "BossBox" && tag != "PlayerDetection" && tag != "Shots" && tag != "BossProjectile" && tag != "Button")
        {
            Destroy(gameObject);

        }

        if(tag == "Enemy")
        {
            //Enemy gets hit
            collision.gameObject.GetComponent<HealthScript>().currentHealth--;
        }
        if (tag == "Boss")
        { 
            collision.gameObject.GetComponent<BossScript>().currentBossHealth--;
        }
    }
}
