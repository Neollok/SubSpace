using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointToCursor : MonoBehaviour {

    //Used to point the weapon towards the mouse

    public int rotationOffset;
    public Rigidbody2D player;
    
    void Update () {
        
        
        Vector3 pPos = player.transform.position;               //Player position. Vector3 is necessary, but z-value useless
        Vector3 mousePos = Input.mousePosition;                 //Mouse position
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);    //Mouse position in game
        mousePos = mousePos - player.transform.position;        //'mousePos' is now the position between player and mouse.



        //Used to flip the weapon

        if (mousePos.x < 0 && rotationOffset !=180)             
        {
            rotationOffset=180;
        }
        else if(mousePos.x > 0 && rotationOffset !=0)
        {
            rotationOffset = 0;
        }

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;      //Fancy formula to tell the angle

        //Sets the rotation. I added the offset to flip it 180 deg when the player turns, but it doesn't shoot probably.
        //Plz help. It's probably not this code's fault but idk
        transform.rotation = Quaternion.AngleAxis(angle-rotationOffset, Vector3.forward);   
        
    }
}
