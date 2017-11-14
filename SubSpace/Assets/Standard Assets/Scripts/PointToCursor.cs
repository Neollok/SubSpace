using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointToCursor : MonoBehaviour
{

    //Used to point the weapon towards the mouse

    public int rotationOffset;
    public Rigidbody2D player;

    void Update()
    {


        Vector3 pPos = player.transform.position;               //Player position. Vector3 is necessary, but z-value useless
        Vector3 mousePos = Input.mousePosition;                 //Mouse position
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);    //Mouse position in game
        mousePos = mousePos - player.transform.position;        //'mousePos' is now the position between player and mouse.




        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;      //Fancy formula to tell the angle

        if (angle > 90 || angle < -90)                                  //If the mouse is to the left of the player
        {
            GameObject player = GameObject.Find("player");             //grabs the player object
            if (player.transform.localScale.x > 0)                     //If player is not scaled to the left
            {
                player.transform.localScale = new Vector3(-1, player.transform.localScale.y, 1);    //flip player to the left

            }
            transform.localScale = new Vector3(-1, -1, -1);             //flip wep to the left
        }
        else
        {
            if (player.transform.localScale.x < 0)                  //same but opposite
            {

                player.transform.localScale = new Vector3(1, player.transform.localScale.y, 1);
            }
            transform.localScale = new Vector3(1, 1, 1);
        }

        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);         //rotate the wep

    }
}
