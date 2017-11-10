using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colliding : MonoBehaviour {

    //UNUSED. Probably useless.

    public bool grounded;
    public bool dJump;
    private bool changeGravity;
    public PlayerMovement pm;
        
	
	void Update () {
        pm = GetComponent<PlayerMovement>();
        grounded = pm.grounded;
        dJump = pm.dJump;
        changeGravity= pm.changeGravity;

        Debug.Log("Active");
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
            dJump = false;
            changeGravity = true;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = false;
        }
    }

}
