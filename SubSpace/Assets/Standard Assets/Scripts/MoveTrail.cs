using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTrail : MonoBehaviour {

    //Used to tell the bullet what to do once spawned.

    public int moveSpeed = 230;             //Bullets speed
    private Vector2 scales;

    
    void Update () { 
        
        transform.Translate(Vector3.right * Time.deltaTime * moveSpeed); //Translate used to move the bullet

        Destroy(gameObject, 2);         //After 2 seconds, delete the instance for the game world
    }
}
