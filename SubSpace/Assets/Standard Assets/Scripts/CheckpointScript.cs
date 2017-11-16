using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointScript : MonoBehaviour {

    public int numberInMap;
    public bool playerPassed = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && !playerPassed)
        {
            GameObject.Find("player").GetComponent<PlayerMovement>().currentCheckpoint = transform.position;
            playerPassed = true;
        }
    }
}
