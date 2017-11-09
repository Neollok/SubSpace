using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    //Camera behavior. Might get changed later-

    private GameObject player;          //Player

    //These values determin how far the camera can go. Creates a "box"

    public float xMin;              //Floats for where the camera can move
    public float xMax;              //Goal is to stop the camera when player moves towards the edge
    public float yMin;              //But can be done in a better way
    public float yMax;              //Because this is manual

    
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");        //Player = player
	}
	
	
	void LateUpdate () {
        float x = Mathf.Clamp(player.transform.position.x, xMin, xMax);
        float y = Mathf.Clamp(player.transform.position.y, yMin, yMax);

        gameObject.transform.position = new Vector3(x, y, gameObject.transform.position.z);
    }
}
