using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour {

    //Used to tell the platform how to move. Only one of the two movements are possible

    public bool horizontalMovement;         //Movement on the X axis
    public bool verticalMovement;           //Movement on the Y axis
    public float maxLength;                 //Max length (up or right) from starting position
    public float minLength;                 //Min length (down or left) from starting position
    public float speed;                     //Speed of the platform

    private float maxPos;                   //Not important to look at
    private float minPos;
    private int moveX;
    private int moveY;
    private bool moveForward;

    void Start()
    {
       
        if (horizontalMovement)                              //Code for horizontal movement
        {
            maxPos = transform.position.x + maxLength;
            minPos = transform.position.x - minLength;
            moveX = 1;
            moveY = 0;

        }
        else if (verticalMovement)                           //Code for vertical movement
        {
            maxPos = transform.position.y + maxLength;
            minPos = transform.position.y - minLength;
            moveY = 1;
            moveX = 0;
        }
    }


 
	
	
	void Update () {
        if(horizontalMovement)                  //Code for horizontal movement
        {
            //Changes direction when reaching max and min value
            if (transform.position.x - minPos < 0) moveX = 1;       

            else if (transform.position.x - maxPos > 0) moveX = -1;
        }

        else if(verticalMovement)                //Code for horizontal movement
        {
            //Changes direction when reaching max and min value
            if (transform.position.y - minPos < 0) moveY = 1;
          
            else if (transform.position.y - maxPos > 0) moveY = -1;
        }

                                                        //Sets velocity for the platform
        GetComponent<Rigidbody2D>().velocity = new Vector3(moveX * speed, moveY * speed, 0);
        
         
        
	}


}
