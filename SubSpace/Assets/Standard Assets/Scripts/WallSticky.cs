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
        if (collision.gameObject.CompareTag("WallDetection") && !pm.grounded)    //If the collision is with the players wall detection
        {
            pm.wallJumpActive = true;                       //Wall jump allowed
        }
    }
    

    void OnTriggerStay2D(Collider2D collision)              //While staying on a trigger (each frame)
    {
        if(collision.gameObject.CompareTag("WallDetection"))    
        {
            
            if(!pm.grounded)
            {
                pm.wallJumpActive = true;           //Wall jump is active
            }
            else
                pm.wallJumpActive = false;



            //Detects which side of the wall the player hits
           
          
            if (transform.position.x + 0.1f - collision.gameObject.transform.position.x > 0)      
            { pm.rightWall = true; }

            else { pm.leftWall = true; }
            
            
        }

    }

    void OnTriggerExit2D(Collider2D collision)                        //When leaving a trigger
    {
        if (collision.gameObject.CompareTag("WallDetection"))         
        {   

            pm.rightWall = false;                                     //Resets all wall bools
            pm.leftWall = false;
            pm.wallJumpActive = false;
        }
    }

}
