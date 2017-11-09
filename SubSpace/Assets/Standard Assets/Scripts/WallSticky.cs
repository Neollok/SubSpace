using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSticky : MonoBehaviour {

    //

    PlayerMovement pm;          //Grabbing PlayerMovement script

    void Start()
    {
        pm = GameObject.Find("player").GetComponent<PlayerMovement>();  //Assigning it to the actual script
    } 

    void OnTriggerEnter2D(Collider2D collision)         //When first colliding with a trigger
    {
        if (collision.gameObject.CompareTag("WallDetection"))    //If the collision is with the players wall detection
        {
            pm.wallJumpActive = true;                       //Wall jump allowed
        }
    }
    

    void OnTriggerStay2D(Collider2D collision)              //While staying on a trigger (each frame)
    {
        if(collision.gameObject.CompareTag("WallDetection"))    
        {
            pm.wallJumpActive = true;                       //Wall jump is active


            //Detects which side of the wall the player hits
            if (transform.position.x + 1 < collision.gameObject.transform.position.x)      
            { pm.rightWall = true; }

            else { pm.leftWall = true; }
            
            //If the player holds to the same side the wall is at, 'onWall' is true
            if (Input.GetKey("a") && transform.position.x + 1 < collision.gameObject.transform.position.x)
            { pm.onWall = true; }

            else if (Input.GetKey("d") && transform.position.x + 1 > collision.gameObject.transform.position.x)
            { pm.onWall = true; }

            
            else { pm.onWall = false; }                               //If not, 'onWall' is false
            
        }

    }

    void OnTriggerExit2D(Collider2D collision)                        //When leaving a trigger
    {
        if (collision.gameObject.CompareTag("WallDetection"))         
        {   

            pm.rightWall = false;                                     //Resets all wall bools
            pm.leftWall = false;
            pm.onWall = false;
            pm.wallJumpActive = false;
        }
    }

}
