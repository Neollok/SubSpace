using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTrail : MonoBehaviour {

    //Used to tell the bullet what to do once spawned.

    public int moveSpeed = 230;             //Bullets speed

    private void Start()
    {
                                        //If the mouse X position - the player position is less than 0
        if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x - GameObject.Find("player").transform.position.x < 0)
        {
            moveSpeed *= -1;            //Then we want the bullets to move the opposite direction as well
        }
    }
 

    void Update () { 
        
        transform.Translate(Vector3.right * Time.deltaTime * moveSpeed); //Translate used to move the bullet

        Destroy(gameObject, 2);         //After 2 seconds, delete the instance for the game world
    }
}
