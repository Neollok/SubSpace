using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSlideL : MonoBehaviour {

    //Detects if the player collides with the wall
    //Using some wall detector colliders on the side of the player

    void OnCollisionStay2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Wall")
        {
            
            if (Input.GetKey("a"))      //
            {
                Debug.Log(0);
                
            }
        }

    }
}
